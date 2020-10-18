using System;
using System.IO;
using System.Threading.Tasks;
using TNHTweaker_UI.BusinessLogic;

namespace TNHTweaker_UI.SerializerTester
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Reading character file");
            var filePath = ".\\character.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Cannout find the character.txt file in the base directory.");
                Console.ReadKey();
                return;
            }

            var characterText = await File.ReadAllLinesAsync(filePath);
            var serializer = new CharacterSerializer();
            var character = serializer.ReadCharacterFromString(characterText);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
