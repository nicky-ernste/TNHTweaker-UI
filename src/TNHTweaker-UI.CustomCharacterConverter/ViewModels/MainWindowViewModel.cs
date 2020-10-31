using Prism.Mvvm;
using PropertyChanged;
using TNHTweaker_UI.BusinessLogic.Interfaces;
using TNHTweaker_UI.CustomCharacterConverter.Views;

namespace TNHTweaker_UI.CustomCharacterConverter.ViewModels
{
    /// <summary>
    /// View model for the <see cref="MainWindow"/> view.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel : BindableBase
    {
        private readonly ICharacterSerializerOld _oldCharacterSerializer;
        private readonly ICharacterSerializer _newCharacterSerializer;
        private readonly ICharacterConverter _characterConverter;

        public string ApplicationTitle { get; set; } = "Take and Hold Custom character converter";

        public MainWindowViewModel(ICharacterSerializerOld oldCharacterSerializer, ICharacterSerializer newCharacterSerializer, ICharacterConverter characterConverter)
        {
            _oldCharacterSerializer = oldCharacterSerializer;
            _newCharacterSerializer = newCharacterSerializer;
            _characterConverter = characterConverter;
        }
    }
}