using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Не очень внятно написано задание, непонятно, как и зачем использовать первую строку из входного файла, 
                //если дальше в условиях сказано, что массив с рузультатами - это оценки по всем студентам, и количество успешно сдавших сессию студентов можно узнать, посчитав лишь количество 
                //оценок > 60
                List<double> successRsults = ReadResults().Where(c => c > 60).ToList();
                int countOfSuccesStudents = successRsults.Count();
                int averageBall = (int)successRsults.Average();

                Console.WriteLine(countOfSuccesStudents);
                Console.WriteLine(averageBall);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                Console.ReadLine();                
            }
        }
        /// <summary>
        /// Приводит первую строку из вводных данных к числовому массиву
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        /// <returns>Массив чисел</returns>
        static List<double> ReadFirstLine(string fileName = "univer.in")
        {
            string firstLine = File.ReadLines(fileName).Take(1).First();
            List<double> firstLineToNumbersArray = new List<double>();
            var numbers = firstLine.Split(' ');
            foreach (var number in numbers)
            {
                var result = double.Parse(number, CultureInfo.InvariantCulture);
                firstLineToNumbersArray.Add(result);
            }
            if (firstLineToNumbersArray.Any(c => c < 0 || c > 1000))
                throw new ArgumentException("У вхідних даних є невірне значення");
            return firstLineToNumbersArray;

        }
        /// <summary>
        /// Читает строки, кроме первой из вводного файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Масив результатов</returns>
        static List<double> ReadResults(string fileName = "univer.in")
        {
            List<string> readResults = File.ReadLines(fileName).Skip(1).ToList();
            List<double> resultsToNumbersArray = new List<double>();
            foreach (var stringResult in readResults)
            {
                var numbers = stringResult.Split(' ');
                foreach (var number in numbers)
                {
                    var result = double.Parse(number, CultureInfo.InvariantCulture);
                    resultsToNumbersArray.Add(result);
                }
            }
            if (resultsToNumbersArray.Any(c => c < 0 || c > 1000))
                throw new ArgumentException("У вхідних даних є невірне значення");
            return resultsToNumbersArray;
        }


    }
}
