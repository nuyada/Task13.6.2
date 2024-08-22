using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string text = File.ReadAllText("C:\\Users\\DALBI\\Desktop\\Text1.txt");

        // Удаление знаков пунктуации
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        char[] delimiters = new char[] { ' ', '\r', '\n' };
        List<string> words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();

        // Подсчет частоты каждого слова
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            string lowerWord = word.ToLower(); // Приведение к нижнему регистру для учета регистра
            if (wordCount.ContainsKey(lowerWord))
            {
                wordCount[lowerWord]++;
            }
            else
            {
                wordCount[lowerWord] = 1;
            }
        }

        // Сортировка слов по частоте и вывод 10 самых часто встречающихся
        var topWords = wordCount.OrderByDescending(pair => pair.Value).Take(10);

        Console.WriteLine("10 самых часто встречающихся слов:");
        foreach (var pair in topWords)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}

