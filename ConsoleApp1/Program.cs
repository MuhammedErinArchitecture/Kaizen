namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            CustomGuidGenerator guidGenerator = new CustomGuidGenerator("ACDEFGHKLMNPRTXYZ23457");
            List<string> generatedGuids = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                string newGuid = guidGenerator.GenerateCustomGuid();
                generatedGuids.Add(newGuid);
                Console.WriteLine("Generated Code " + (i + 1) + ": " + newGuid);
            }

            int uniqueCount = generatedGuids.Distinct().Count();
            bool hasDuplicates = generatedGuids.Count != generatedGuids.Distinct().Count();            
            Console.WriteLine($"Duplicates Exist: {hasDuplicates}");
            Console.WriteLine($"Unique Count : {uniqueCount}");
        }
    }
}