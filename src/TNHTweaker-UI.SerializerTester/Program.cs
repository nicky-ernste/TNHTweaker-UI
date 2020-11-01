using System;
using System.IO;
using System.Threading.Tasks;
using TNHTweaker_UI.BusinessLogic;

namespace TNHTweaker_UI.SerializerTester
{
    public class Program
    {
        //TODO remove this console application when the WPF UI can read and write files.
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Reading character file");
            var filePath = ".\\character.txt";
            var writePath = ".\\exportedCharacter.json";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Cannot find the character.json file in the base directory.");
                Console.ReadKey();
                return;
            }

            var characterText = await File.ReadAllLinesAsync(filePath);
            var serializer = new CharacterSerializerOld();
            var converter = new CharacterConverter();
            var character = serializer.ReadCharacterFromStringOldFormat(characterText);

            if (character != null)
            {
                Console.WriteLine($"Parsed character: {character.DisplayName}");
                Console.WriteLine(character.Description);
            }

            var convertedCharacter = converter.ConvertCharacterToNewFormat(character);
            if (convertedCharacter != null)
            {
                Console.WriteLine($"Converted character: {convertedCharacter.DisplayName}");
                Console.WriteLine(convertedCharacter.Description);
            }

            var newSerializer = new CharacterSerializer();
            var charString = newSerializer.WriteCharacterToString(convertedCharacter);
            if (!string.IsNullOrEmpty(charString))
            {
                Console.WriteLine($"Writing character to {writePath}");
                await File.WriteAllTextAsync(writePath, charString);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}