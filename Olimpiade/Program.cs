using System;
namespace Lights
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введіть L:");
                int l = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть W:");
                int w = int.Parse(Console.ReadLine());
                if (l < 1 || l > 1000 || w < 1 || w > 1000)
                    throw new ArgumentException("Введено некоректні дані");

                int result = Calculate(l, w);
                Console.WriteLine(result);
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Метод, считающий площадь здания
        /// </summary>
        /// <param name="l">длина здания</param>
        /// <param name="w">ширина здания</param>
        /// <returns>Необходимое количество ламп для освещения</returns>
        static int Calculate(int l, int w)
        {
            int totalArea = w * l;
            int areaPerOneLamp = 4;
            if (totalArea % areaPerOneLamp != 0)
                return (totalArea / areaPerOneLamp) + 1;
            return totalArea / areaPerOneLamp;
        }

        //TODO: Реализовать методы для чтения и записи файлов
        static void ReadFile(string pathToFile = "lights.in")
        {

        }
        static void WriteFile(string fileName = "lights.out")
        {

        }
    }
}
