using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Deserialize
{
    // Разработать программу для получения информации о товаре из json-файла.
    public class Goods
    {
        public int[] GoodsCode { get; set; }
        public string[] GoodsName { get; set; }
        public double[] GoodsPrice { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\aqml\source\repos\HomeWork16\HomeWork16\bin\Debug\Products.json";
            string jsonString = File.ReadAllText(fileName);
            Goods goods = JsonSerializer.Deserialize<Goods>(jsonString);

            Console.WriteLine("Код товара:");
            Array.ForEach(goods.GoodsCode, Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine("Нименование товара:");
            Array.ForEach(goods.GoodsName, Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine("Стоимость товара:");
            Array.ForEach(goods.GoodsPrice, Console.WriteLine);
            Console.WriteLine();

            double max = goods.GoodsPrice.Max();
            int indexMax = Array.IndexOf(goods.GoodsPrice, max);

            Console.WriteLine("Название самого дорогого товара: {0}", goods.GoodsName[indexMax]);

            Console.ReadKey();
        }
    }
}
