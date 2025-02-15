namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> firstInputElements = new List<string>();
            List<string> secondInputElements = new List<string>();
            using (StreamReader firstInputReader = new StreamReader(firstInputFilePath))
            {
                while (!firstInputReader.EndOfStream)
                {
                    string line = firstInputReader.ReadLine();
                    firstInputElements.Add(line);
                }
            }
            using (StreamReader secondInputReader = new StreamReader(secondInputFilePath))
            {
                while (!secondInputReader.EndOfStream)
                {
                    string line = secondInputReader.ReadLine();
                    secondInputElements.Add(line);
                }
            }

            using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
            {
                while (firstInputElements.Count > 0 || secondInputElements.Count > 0)
                {
                    if (firstInputElements.Count > 0)
                    {
                        outputWriter.WriteLine(firstInputElements[0]);
                        firstInputElements.RemoveAt(0);
                    }
                    if (secondInputElements.Count > 0)
                    {
                        outputWriter.WriteLine(secondInputElements[0]);
                        secondInputElements.RemoveAt(0);
                    }
                }
            }
        }
    }
}