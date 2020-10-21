using TNHTweaker_UI.Models;

namespace TNHTweaker_UI.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface that defines the serializer for custom H3VR characters.
    /// </summary>
    public interface ICharacterSerializer
    {
        /// <summary>
        /// Attempts to read in a custom character from a text string, typically the contents of a custom character text file.
        /// Reads, parses and puts the data into a <see cref="CharacterInfo"/> object.
        /// </summary>
        /// <param name="characterDefinition">The full character definition to parse.</param>
        /// <returns>A <see cref="CharacterInfo"/> instance with the given <paramref name="characterDefinition"/>. Or <c>null</c> if parsing encountered an error.</returns>
        CharacterInfo ReadCharacterFromString(string[] characterDefinition);

        /// <summary>
        /// Writes the given <paramref name="character"/> as a text string that can be written to a customer character text file.
        /// </summary>
        /// <param name="character">The <see cref="CharacterInfo"/> instance to write out as a string definition.</param>
        /// <returns>A custom character string notation of the given <paramref name="character"/>.</returns>
        string WriteCharacterToString(CharacterInfo character);
    }
}