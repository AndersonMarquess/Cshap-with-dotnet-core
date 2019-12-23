using System.Globalization;

namespace OperacoesComLinq.Models {
    class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public Product(int id, string name, double price) {
            Id = id;
            Name = name;
            Price = price;
        }

        public Product() {
        }

        public void PrintState() {
            var formatedPrice = Price.ToString("F2", CultureInfo.InvariantCulture);
            System.Console.WriteLine($"{Id} - {Name} - {formatedPrice} - {Category.Name}");
        }
    }
}