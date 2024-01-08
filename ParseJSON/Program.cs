using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProductsJSON;
using System.Text.Json;

namespace ParseJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using(StreamReader sr = new StreamReader ("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
                Item[] items = JsonSerializer.Deserialize<Item[]>(jsonString);

                Item maxItem = items[0];
                foreach (Item i in items )
                {
                    if(i.itemPrice > maxItem.itemPrice)
                    {
                        maxItem = i;
                    }
                }

                Console.WriteLine($"{maxItem.itemCode} {maxItem.itemName} {maxItem.itemPrice}");
                Console.ReadKey();
            }
        }
    }
}
