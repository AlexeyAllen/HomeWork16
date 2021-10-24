using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Serialize
{
    // Разработать программу для записи информации о товаре в текстовый файл в формате json.
    public class Goods
    {
        public int[] GoodsCode { get; set; }
        public string[] GoodsName { get; set; }
        public double[] GoodsPrice { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string[,] goodsArray = new string[5, 3];
            int[] GoodsCode1 = new int[5];
            string[] GoodsName1 = new string[5];
            double[] GoodsPrice1 = new double[5];

            Console.WriteLine("Введите следующие значения для 5 товаров");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Для товара {0}:", i + 1);

                for (int j = 0; j < 3; j++)
                {
                    Console.Write("Введите код товара (целое число): ");
                    goodsArray[i, j] = Console.ReadLine();
                    Console.Write("Введите наименование товара: ");
                    goodsArray[i, ++j] = Console.ReadLine();
                    Console.Write("Введите стоимость товара: ");
                    goodsArray[i, ++j] = Console.ReadLine();
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; ;)
                {
                    GoodsCode1[i] = Convert.ToInt32(goodsArray[i, j]);
                    GoodsName1[i] = goodsArray[i, j + 1];
                    GoodsPrice1[i] = Convert.ToDouble(goodsArray[i, j + 2]);
                    break;
                }
            }

            var goods = new Goods()
            {
                GoodsCode = new[] { GoodsCode1[0], GoodsCode1[1], GoodsCode1[2], GoodsCode1[3], GoodsCode1[4] },
                GoodsName = new[] { GoodsName1[0], GoodsName1[1], GoodsName1[2], GoodsName1[3], GoodsName1[4] },
                GoodsPrice = new[] { GoodsPrice1[0], GoodsPrice1[1], GoodsPrice1[2], GoodsPrice1[3], GoodsPrice1[4] }
            };

            string fileName = "Products.json";
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            string jsonString = JsonSerializer.Serialize(goods, options);
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine(File.ReadAllText(fileName));

            Console.ReadKey();
        }
    }
}
