
namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader inputReader = new StreamReader(inputFilePath))
            {
                using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
                {
                    int rowsCount = 0;
                    while (!inputReader.EndOfStream)
                    {
                        string line = inputReader.ReadLine();
                        if (rowsCount % 2 != 0)
                        {
                            outputWriter.WriteLine(line);
                        }
                        rowsCount++;
                    }
                }
            }
        }
    }
}