using System;
using System.Collections.Generic;
using System.Globalization;
using exercicioHerancaPolimorfismo.Models;

namespace exercicioHerancaPolimorfismo {
    class Program {

        static List<Product> products = new List<Product>();

        static void Main(string[] args) {
            Console.Write("Enter the number of products? ");
            int numberOfProducts = int.Parse(Console.ReadLine());

            ReceiveAmountProductData(numberOfProducts);
            PrintPriceTagInProducts();
        }

        private static void PrintPriceTagInProducts() {
            foreach (var product in products) {
                Console.WriteLine(product.PriceTag());
            }
        }

        private static void ReceiveAmountProductData(int numberOfProducts) {
            for (int i = 1; i <= numberOfProducts; i++) {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, Used or Imported (c/u/i)? ");
                char typeOfProduct = char.Parse(Console.ReadLine());

                if (typeOfProduct == 'i') {
                    products.Add(GetNewImportedProduct());
                } else if (typeOfProduct == 'u') {
                    products.Add(GetNewUsedProduct());
                } else if (typeOfProduct == 'c') {
                    products.Add(GetNewCommonProduct());
                }
            }
        }

        private static Product GetNewCommonProduct() {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            return new Product(name, price);
        }

        private static Product GetNewUsedProduct() {
            Product product = GetNewCommonProduct();
            Console.Write("Manufacture date (DD/MM/YYYY): ");
            DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
            return new UsedProduct(product.Name, product.Price, manufactureDate);
        }

        private static Product GetNewImportedProduct() {
            Product product = GetNewCommonProduct();
            Console.Write("Custom fee: ");
            double customFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            return new ImportedProduct(product.Name, product.Price, customFee);
        }
    }
}