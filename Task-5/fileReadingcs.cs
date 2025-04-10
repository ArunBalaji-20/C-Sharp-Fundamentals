using System;
using System.IO;

namespace task5
{
    public class fileReading
    {
        
       static void Main(string[] args)
        {
            //Console.WriteLine("hello");
            try
            {
                string[] inpFile = File.ReadAllLines("E:\\c#-Fundamentals\\ConsoleApp2\\file.csv");
                int nLine = 0;
                int nWord = 0;
                foreach (string line in inpFile)
                {
                    Console.WriteLine(line);
                    nLine++;

                    string[] words = line.Split(' ', ',');
                    foreach (string word in words)
                    {
                        nWord++;
                    }

                }
                Console.WriteLine("number of lines:" + nLine);
                Console.WriteLine("number of words:" + nWord);

                string nLines = $"number of lines :{nLine}";
                string nWords = $"number of words: {nWord}";

                string[] arr = [nLines, nWords];


                string outputFile = "E:\\c#-Fundamentals\\ConsoleApp2\\output.txt";
                File.WriteAllLines(outputFile, arr);
                Console.WriteLine("Written in output.txt");
            }
            catch (FileNotFoundException ex)
            {

                Console.WriteLine($"file not found , enter a valid file name. {ex.Message}");

            }
            catch (IOException ex)
            {
                Console.WriteLine($"error occured:{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some error occured: {ex.Message}");
            }

        }
    }

}

