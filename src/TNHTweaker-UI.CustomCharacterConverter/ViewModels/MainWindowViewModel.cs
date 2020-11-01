using System.IO;
using System.Windows.Input;
using Microsoft.Win32;
using Prism.Commands;
using PropertyChanged;
using TNHTweaker_UI.BusinessLogic.Interfaces;
using TNHTweaker_UI.CustomCharacterConverter.Views;
using TNHTweaker_UI.Models.OldFormat;

namespace TNHTweaker_UI.CustomCharacterConverter.ViewModels
{
    /// <summary>
    /// View model for the <see cref="MainWindow"/> view.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel
    {
        /// <summary>
        /// An instance of <see cref="ICharacterSerializerOld"/> that can load custom characters in the old format.
        /// </summary>
        private readonly ICharacterSerializerOld _oldCharacterSerializer;

        /// <summary>
        /// An instance of <see cref="ICharacterSerializer"/> that can load and write custom characters in the new format.
        /// </summary>
        private readonly ICharacterSerializer _newCharacterSerializer;

        /// <summary>
        /// An instance of <see cref="ICharacterConverter"/> that can convert characters from the old format to the new one.
        /// </summary>
        private readonly ICharacterConverter _characterConverter;

        /// <summary>
        /// The loaded custom character to convert.
        /// </summary>
        private CharacterInfo _loadedCharacter;

        /// <summary>
        /// The title of the main application window.
        /// </summary>
        /// TODO Convert any front facing text to a resource file.
        public string ApplicationTitle { get; set; } = "Take and Hold Custom character converter";

        /// <summary>
        /// The full path to the custom character file that should be loaded.
        /// </summary>
        public string CharacterFilePath { get; set; }

        /// <summary>
        /// <c>true</c> if a custom character is loaded and can be converted. <c>false</c> otherwise.
        /// </summary>
        public bool CanConvertCharacter { get; set; }

        /// <summary>
        /// The user friendly status of the conversion or other messages.
        /// </summary>
        public string ConversionStatusLog { get; set; }

        /// <summary>
        /// Command that is executed when the browse button is pressed to load a custom character file.
        /// </summary>
        public ICommand BrowseButtonCommand { get; set; }

        /// <summary>
        /// Command that is executed when the convert character button is pressed.
        /// </summary>
        public ICommand ConvertCharacterButtonCommand { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="MainWindowViewModel"/> with it's dependencies.
        /// </summary>
        /// <param name="oldCharacterSerializer">An instance of <see cref="ICharacterSerializerOld"/> that can load custom characters in the old format.</param>
        /// <param name="newCharacterSerializer">An instance of <see cref="ICharacterSerializer"/> that can load and write custom characters in the new format.</param>
        /// <param name="characterConverter">An instance of <see cref="ICharacterConverter"/> that can convert characters from the old format to the new one.</param>
        public MainWindowViewModel(ICharacterSerializerOld oldCharacterSerializer, ICharacterSerializer newCharacterSerializer, ICharacterConverter characterConverter)
        {
            _oldCharacterSerializer = oldCharacterSerializer;
            _newCharacterSerializer = newCharacterSerializer;
            _characterConverter = characterConverter;

            BrowseButtonCommand = new DelegateCommand(BrowseForCharacterFile);
            ConvertCharacterButtonCommand = new DelegateCommand(ConvertCharacter, () => CanConvertCharacter)
                .ObservesProperty(() => CanConvertCharacter);
        }

        /// <summary>
        /// Opens a file browser window that allows the user to select a custom character file to convert.
        /// </summary>
        private void BrowseForCharacterFile()
        {
            //TODO put into a service.
            var openFileDialog = new OpenFileDialog
            {
                Filter = "H3VR custom character file | *.txt",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                ValidateNames = true,
                Title = "Please select a H3VR custom character in the old format. (So not the .json files)"
            };

            var dialogCloses = openFileDialog.ShowDialog();
            if (!dialogCloses.HasValue || !dialogCloses.Value)
                return;

            CharacterFilePath = openFileDialog.FileName;
            LoadCustomCharacter();
        }

        /// <summary>
        /// Converts the custom character loaded into <see cref="_loadedCharacter"/> and writes it to the same path as <see cref="CharacterFilePath"/>
        /// </summary>
        private void ConvertCharacter()
        {
            if (_loadedCharacter == null || string.IsNullOrEmpty(CharacterFilePath))
                return;

            CanConvertCharacter = false;

            var convertedCharacter = _characterConverter.ConvertCharacterToNewFormat(_loadedCharacter);
            if (convertedCharacter == null)
            {
                ConversionStatusLog = $"Could not convert the loaded character at \"{CharacterFilePath}\"\r\nCheck if the format is correct according to the old style.";
                CanConvertCharacter = true;
                return;
            }

            var convertedCharacterJson = _newCharacterSerializer.WriteCharacterToString(convertedCharacter);
            var directoryPath = new FileInfo(CharacterFilePath).DirectoryName;
            if (directoryPath == null)
            {
                ConversionStatusLog = $"The path at: \"{CharacterFilePath}\" doesn't seem to exist";
                return;
            }

            try
            {
                File.WriteAllText(Path.Combine(directoryPath, "convertedCharacter.json"), convertedCharacterJson);
                ConversionStatusLog = $"The custom character was successfully converted and written to: \"{Path.Combine(directoryPath, "convertedCharacter.json")}\"";

                //Reset values.
                _loadedCharacter = null;
                CharacterFilePath = string.Empty;
            }
            catch (IOException e)
            {
                ConversionStatusLog = $"Could not write custom character file at: \"{CharacterFilePath}\"\r\nThe following error occurred: {e.Message}";
                CanConvertCharacter = true;
            }
        }

        /// <summary>
        /// Loads a custom character into <see cref="_loadedCharacter"/> from the given <see cref="CharacterFilePath"/> for conversion.
        /// </summary>
        private void LoadCustomCharacter()
        {
            if (string.IsNullOrEmpty(CharacterFilePath))
                return;

            try
            {
                _loadedCharacter = _oldCharacterSerializer.ReadCharacterFromStringOldFormat(File.ReadAllLines(CharacterFilePath));
                CanConvertCharacter = _loadedCharacter != null;
                if (_loadedCharacter != null)
                    ConversionStatusLog = $"Character successfully loaded: {_loadedCharacter.DisplayName}";
            }
            catch (IOException e)
            {
                ConversionStatusLog = $"Could not load custom character file at: \"{CharacterFilePath}\"\r\nThe following error occurred: {e.Message}";
                CanConvertCharacter = false;
            }
        }
    }
}