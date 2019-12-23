using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OperacoesComLinq.Models;

namespace OperacoesComLinq {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("\nLanguage Integrated Query (LINQ)");

            Category tools = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category computers = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category eletronics = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> products = new List<Product>() {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = computers },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = tools },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = eletronics },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = computers },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = tools },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = computers },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = eletronics },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = eletronics },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = computers },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = eletronics },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = tools }
            };

            Console.WriteLine("\nTier 1 AND Price < 900 (Where -> Filter)");
            products
                .Where(p => p.Price < 900 && p.Category.Tier == 1)
                .ToList()
                .ForEach(p => p.PrintState());

            Console.WriteLine("\nNames of products from tools (Select -> Map)");
            products
                .Where(p => p.Category == tools)
                .Select(p => p.Name)
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("\nObjeto anônimo criado com base nos atributos escolhidos");
            products
                .Where(p => p.Name.ToUpper()[0] == 'C')
                //Para evitar ambiguidades CategoryName é um alias, não é possível sar atributos com nomes iguais.
                .Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name })
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("\nOrdene ASC por preço, se houver empate, ordene por nome");
            products
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .ToList()
                .ForEach(p => p.PrintState());

            Console.WriteLine("\nO Maior valor com base no preço");
            var maiorValor = products.Max(p => p.Price);
            Console.WriteLine(maiorValor.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine("\nSoma dos preços dos itens da categoria 1");
            var soma = products.Where(p => p.Category == tools).Sum(p => p.Price);
            Console.WriteLine(soma.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine("\nSoma dos preços dos itens na categoria 2 (Select + Aggregate -> Reduce)");
            var reduce = products.Where(p => p.Category == computers).Select(p => p.Price).Aggregate(0.0, (sigma, valorAtual) => sigma + valorAtual);
            Console.WriteLine(reduce.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine("\nAgrupa os produtos de acordo com sua categoria");
            var produtosAgrupados = products.GroupBy(p => p.Category);
            foreach (IGrouping<Category, Product> group in produtosAgrupados) {
                Console.WriteLine("Categoria: " + group.Key.Name);
                group.ToList().ForEach(p => p.PrintState());
            }
        }
    }
}
