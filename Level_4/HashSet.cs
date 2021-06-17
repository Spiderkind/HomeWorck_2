using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Randoms
{
    public string ran { get; set; }
    public override bool Equals(object obj)
    {
        var user = obj as Randoms;
        if (user == null)
            return false;
        return ran == user.ran;
    }
    public override int GetHashCode()
    {
        int firtsNameHashCode = ran?.GetHashCode() ?? 0;
        return firtsNameHashCode;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var hashSet = new HashSet<Randoms>();
        string[] array = new string[10001];
        char[] letters = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        Random rand = new Random();
        for (int i = 0; i <= array.Length - 1; i++)
        {
            string word = "";
            for (int j = 1; j <= 5; j++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }
            array[i] = word;
            var word2 = new Randoms() { ran = word };
            hashSet.Add(word2);
        }
        string searchstring = "U9FH2";
        var word1 = new Randoms() { ran = searchstring };
        Stopwatch arraytest = new Stopwatch();
        Stopwatch hashtst = new Stopwatch();
        arraytest.Start();
        foreach (var st in array)
        {
            if (st.Contains(searchstring))
            {
                Console.WriteLine("Yes", st);
            }
        }
        arraytest.Stop();
        hashtst.Start();
        foreach (var st in hashSet)
        {
            if (st.ran.Contains(searchstring))
            {
                Console.WriteLine("Yes", st.ran);
            }
        }
        hashtst.Stop();
        Console.WriteLine($"Time in ticks for mass search: {arraytest.ElapsedTicks}");
        Console.WriteLine($"Time in ticks for hash search: {hashtst.ElapsedTicks}");
    }
}