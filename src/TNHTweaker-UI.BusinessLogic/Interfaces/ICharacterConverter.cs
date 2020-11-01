using TNHTweaker_UI.Models;
using TNHTweaker_UI.Models.OldFormat;

namespace TNHTweaker_UI.BusinessLogic.Interfaces
{
    public interface ICharacterConverter
    {
        /// <summary>
        /// Converts a custom character from the old format to the new JSON based format.
        /// </summary>
        /// <param name="oldCharacter">The loaded old custom character to convert.</param>
        /// <returns>An instance of <see cref="CharacterInformation"/> that is converted from the given <paramref name="oldCharacter"/>.</returns>
        CharacterInformation ConvertCharacterToNewFormat(CharacterInfo oldCharacter);
    }
}