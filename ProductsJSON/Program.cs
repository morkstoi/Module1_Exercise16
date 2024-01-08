using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace ProductsJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Item[] items = new Item[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара:");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара:");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену товара:");
                double price = Convert.ToInt32(Console.ReadLine());

                items[i] = new Item() { itemCode = code, itemName = name, itemPrice = price };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(items, options);

            using (StreamWriter sw = new StreamWriter ("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }

        }
    }
}
