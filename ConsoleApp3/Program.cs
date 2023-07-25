using System.Text;

namespace ConsoleApp3
{
    internal class Program
    {
        static string allowedCharacters = "ACDEFGHKLMNPRTXYZ23457";
        static Random random = new Random();

        static string GenerateCustomGuid()
        {
            int allowedCharsLength = allowedCharacters.Length;
            List<char> uniqueChars = allowedCharacters.ToList();

            int n = allowedCharsLength;
            int k = 8;

            StringBuilder customGuid = new StringBuilder();

            for (int i = 0; i < k; i++)
            {
                int index = random.Next(n);
                customGuid.Append(uniqueChars[index]);
                uniqueChars.RemoveAt(index);
                n--;
            }

            return customGuid.ToString();
        }

        static void Main(string[] args)
        {
            HashSet<string> generatedGuids = new HashSet<string>();

            for (int i = 0; i < 1000000; i++)
            {
                string newGuid = GenerateCustomGuid();

                if (generatedGuids.Contains(newGuid))
                {
                    Console.WriteLine("Duplicated code generated: " + newGuid);
                    break;
                }

                generatedGuids.Add(newGuid);
                Console.WriteLine("Generated Code " + (i + 1) + ": " + newGuid);
            }

            Console.WriteLine("Total unique codes generated: " + generatedGuids.Count);
        }
    }
}