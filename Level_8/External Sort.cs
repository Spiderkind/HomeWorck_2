using System;
using System.IO;

namespace _2
{
    class Program
    {
        // в mass.txt числа должны располагаться так: 12 12 323 434 
        //т.е. после каждого числа пробел.     
        static string path = "mass.txt";
        static string pathtoSave = "Sortedmass.txt";
        static int error = 0;
        static void Main(string[] args)
        {
            if (File.Exists(pathtoSave))
                File.Delete(pathtoSave);
            /*
            //Чтобы заполнить mass.txt случаными числами от 0 до 10000
            Random rand = new Random();
            for (int i = 0; i < 10000; i++)
                File.AppendAllText(path, Convert.ToString(rand.Next(0, 100)) + " ");
            */
            Breaks();
            if (error == 0)
                Console.WriteLine("Файл обработан успешно");
        }
        public static void Breaks()
        {
            int maxfiles = Maximum();
            int numinfiles = 100;
            using (StreamReader file = new StreamReader(path))
            {
                string text = "";
                while (file.Peek() != -1)
                {
                    while (file.Peek() != 32)
                        text += (char)file.Read();
                    string number = text;
                    int block = (Convert.ToInt32(number) / (numinfiles));
                    string SavePath = Convert.ToString(block + ".txt");
                    File.AppendAllText(SavePath, number + Environment.NewLine);
                    file.Read();
                    text = "";
                }
            }
            for (int i = 0; i < maxfiles; i++)
            {
                if (File.Exists(i + ".txt"))
                {
                    Sort(i + ".txt");
                    int j = 1;
                    AddtoFile(i + ".txt");
                }
            }

        }
        public static void Sort(string path)
        {
            int count = 0;
            foreach (string line in File.ReadLines(path))
                count++;
            int[] array = new int[count];
            int i = 0;
            foreach (string line in File.ReadLines(path))
            {
                array[i] = Convert.ToInt32(line);
                i++;
            }
            array = Sortarray(array);
            File.Create(path).Close();
            foreach (var a in array)
                File.AppendAllText(path, a + Environment.NewLine);
        }
        public static int[] Sortarray(int[] input)
        {
            int temp;
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] > input[j])
                    {
                        temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }
            return input;
        }
        public static void AddtoFile(string path)
        {
            foreach (string line in File.ReadLines(path))
                File.AppendAllText(pathtoSave, line + " ");
            File.Delete(path);
        }
        public static int Maximum()
        {
            int max = 0;
            int j = 0;
            string text = "";
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    while (file.Peek() != -1)
                    {
                        while (file.Peek() != 32)
                            text += (char)file.Read();
                        int number = Convert.ToInt32(text);
                        if (number > max)
                            max = number;
                        file.Read();
                        text = "";
                    }
                }
            }
            catch
            {
                Console.WriteLine("Файл содержит не читаемы символы: буквы или знаки припенания либо лишние пробелы");
                error = 1;
                return -1;
            }
            while (max >= 10)
            {
                max /= 10;
                j++;
            }
            if (j == 0)
                j = 1;
            int output = Convert.ToInt32(Math.Pow(10, j - 1));
            return output;
        }
    }
}
