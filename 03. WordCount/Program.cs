namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            using (StreamReader wordReader = new StreamReader(wordsFilePath))
            {
                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    int wordCount = 0;
                    foreach (var line in File.ReadLines(wordsFilePath))
                    {
                        string[] elements = line.Split(' ');

                        foreach (var element in elements)
                        {
                            foreach (var newLine in File.ReadLines(textFilePath))
                            {
                                string[] newElements = newLine.Split(new char[] { ' ', '-', ',', '.' });

                                foreach (var newElement in newElements)
                                {
                                    if (element == newElement.ToLower())
                                    {
                                        if (!wordCounts.ContainsKey(element))
                                        {
                                            wordCounts.Add(element, 1);
                                        }
                                        else
                                        {
                                           wordCounts[element]++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            wordCounts = wordCounts.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
            {
                foreach (var item in wordCounts)
                {
                    outputWriter.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}