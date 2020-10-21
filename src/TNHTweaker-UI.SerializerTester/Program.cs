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
            var writePath = ".\\exportedCharacter.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Cannot find the character.txt file in the base directory.");
                Console.ReadKey();
                return;
            }

            var characterText = await File.ReadAllLinesAsync(filePath);
            var serializer = new CharacterSerializer();
            var character = serializer.ReadCharacterFromString(characterText);

            if (character != null)
            {
                Console.WriteLine($"Parsed character: {character.DisplayName}");
                Console.WriteLine(character.Description);
            }

            var charString = serializer.WriteCharacterToString(character);
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