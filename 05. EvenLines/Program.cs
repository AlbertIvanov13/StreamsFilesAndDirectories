namespace EvenLines
{
    using System;
    using System.Threading.Channels;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader inputReader = new StreamReader(inputFilePath))
            {
                int count = 0;
                while (!inputReader.EndOfStream)
                {
                    string line = inputReader.ReadLine();
                    string[] items = line.Split(' ');
                    List<string> lines = new List<string>();
                    foreach (var item in items)
                    { 
                        lines.Add(item.ToString());
                    }
                    lines.Reverse();
                    string newString = string.Join(" ", lines);
                    foreach (var item in newString)
                    {
                        if (item == '-' || item == '.' || item == ',' || item == '!' || item == '?')
                        {
                            newString = newString.Replace(item, '@');
                        }
                    }
                    if (count % 2 == 0)
                    {
                        Console.WriteLine(newString);
                    }
                    count++;
                }
            }
            
            return "";
        }
    }
}