using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using exercicioLinq.Models;

namespace exercicioLinq {
    class Program {
        static void Main(string[] args) {
            var path = Directory.GetCurrentDirectory();
            var fileName = "products.csv";
            List<Product> products = readProductsFromFile(path, fileName);

            var avgPrice = GetAveragePriceIn(products);
            Console.WriteLine("Average price: " + avgPrice.ToString("F2", CultureInfo.InvariantCulture));

            products
                .Where(p => p.Price < avgPrice)
                .OrderByDescending(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine(p.Name));
        }

        private static double GetAveragePriceIn(List<Product> products) {
            return products.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
        }

        private static List<Product> readProductsFromFile(string path, string fileName) {
            var products = new List<Product>();

            using (StreamReader streamReader = File.OpenText($"{path}/{fileName}")) {
                while (!streamReader.EndOfStream) {
                    var fields = streamReader.ReadLine().Split(",");
                    var name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    products.Add(new Product(name, price));
                }
            }

            return products;
        }
    }
}
