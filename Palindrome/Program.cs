using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //string input = "BAOBAB";
                string input = Console.ReadLine();
                if (input.Length < 1 || input.Length > 60)
                    throw new ArgumentException("Введено невірне значення");
                //Счетчик палиндромов установлен в ноль
                int resultCount = 0;
                //находим все возможные варианты комбинаций индексов символов в массиве для вычеркивания
                var allPossibleDeletionPositions = GetAllCombos(Enumerable.Range(0, input.Length).ToList());
                //идем в цикле по всем возможным комбинациям и вычеркиваем символы, каждый результат проверяем на палиндром
                foreach (var combination in allPossibleDeletionPositions)
                {
                    string attempt = RemoveChars(input, combination);
                    if (IsPalindrome(attempt))
                    {
                        //инкрементируем счетчик
                        resultCount++;
                        Console.WriteLine(attempt + " is a palindrome;");
                    }
                    else
                    {
                        Console.WriteLine(attempt + " is not a palindrome;");
                    }
                }
                Console.WriteLine(resultCount);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key");
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Метод для вычеркивания символов из строки
        /// </summary>
        /// <param name="input">входная строка</param>
        /// <param name="indexes">индексы, по которым надо вычеркнуть символы</param>
        /// <returns></returns>
        public static string RemoveChars(string input, List<int> indexes)
        {        
            //преобразовали строку в набор символов
            List<char> chars = input.Select(c=>c).ToList();
            //отсортировали индексы в порядке убывания. (Зачем?) и поудаляли не нужные, вернули новую строку
            foreach (var index in indexes.OrderByDescending(c=>c))
                chars.RemoveAt(index);
            return new string(chars.ToArray());
        }
        /// <summary>
        /// Метод для нахождения всех возможных комбинаций 
        /// </summary>
        /// <typeparam name="T">обобщенный тип данных для входящей коллекции, в этом случае это набор индексов</typeparam>
        /// <param name="list"></param>
        /// <returns>Коллекция коллекций со всеми комбинациями</returns>
        public static List<List<T>> GetAllCombos<T>(List<T> list)
        {
            int comboCount = (int)Math.Pow(2, list.Count);
            List<List<T>> result = new List<List<T>>();
            for (int i = 1; i < comboCount; i++)
            {
                // make each combo here
                result.Add(new List<T>());
                for (int j = 0; j < list.Count; j++)
                {
                    if ((i >> j) % 2 != 0)
                        result.Last().Add(list[j]);
                }
            }
            return result;
        }

       /// <summary>
       /// Метод проверки строки на палиндром
       /// </summary>
       /// <param name="value">входная строка</param>
       /// <returns>да или нет</returns>
        public static bool IsPalindrome(string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }
    }
}
