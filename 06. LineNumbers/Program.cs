namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            int lineNumber = 0;
            int symbols = 0;
            int punctuation = 0;
            string[] lines = File.ReadAllLines(inputFilePath);
            List<string> texts = new List<string>();
            foreach (string line in lines)
            {
                lineNumber++;
                foreach (var symbol in line)
                {
                    if (char.IsPunctuation(symbol))
                    {
                        punctuation++;
                    }
                    else if (char.IsLetter(symbol))
                    {
                        symbols++;
                    }
                }
                string text = $"Line {lineNumber}: {line} ({symbols})({punctuation})";
                texts.Add(text);
                symbols = 0;
                punctuation = 0;
            }
            File.WriteAllLines(outputFilePath, texts);
        }
    }
}