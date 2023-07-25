namespace ConsoleApp1
{
    public class CustomGuidGenerator
    {
        private string allowedCharacters;
        private Random random;     

        public CustomGuidGenerator(string allowedChars)
        {
            allowedCharacters = allowedChars;
            random = new Random();
        }

        public string GenerateCustomGuid()
        {
            int allowedCharsLength = allowedCharacters.Length;
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();            
            string uniquePart = "";
            int index = (int)(timestamp % allowedCharsLength);
            uniquePart = allowedCharacters[index].ToString();
            string customGuid = string.Join("", Enumerable.Range(0, 7).Select(_ => allowedCharacters[random.Next(allowedCharsLength)]));
            customGuid = uniquePart + customGuid;
            var shuflleValue = new Random().Next(0, 2);

            return shuflleValue == 0 ? FisherShuffleText(customGuid) : shuflleValue == 1 ? ShuffleText(customGuid) : customGuid;
        }

        // Fisher-Yates Shuffle Algorithm
        private string FisherShuffleText(string text)
        {
            char[] characters = text.ToCharArray();
            int n = characters.Length;
            Random rng = new Random();

            while (n > 1)
            {
                int k = rng.Next(n--);
                char temp = characters[n];
                characters[n] = characters[k];
                characters[k] = temp;

                for (int i = 0; i < 10; i++)
                {
                    int randomIndex = rng.Next(n + 1);
                    char tempChar = characters[randomIndex];
                    characters[randomIndex] = characters[n];
                    characters[n] = tempChar;
                }
            }

            return new string(characters);
        }

        private string ShuffleText(string text)
        {
            char[] characters = text.ToCharArray();
            int n = characters.Length;
            Random random = new Random();

            for (int i = 0; i < n - 1; i++)
            {
                int randomIndex = random.Next(i, n);
                char value = characters[randomIndex];
                characters[randomIndex] = characters[i];
                characters[i] = value;
            }

            return new string(characters);
        }
    }
}
