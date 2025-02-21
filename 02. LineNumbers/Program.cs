﻿namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader inputReader = new StreamReader(inputFilePath))
            {
                using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
                {
                    int count = 0;
                    while (!inputReader.EndOfStream)
                    {
                        string line = inputReader.ReadLine();
                        outputWriter.WriteLine($"{++count}. {line}");
                    }
                }
            }
        }
    }
}