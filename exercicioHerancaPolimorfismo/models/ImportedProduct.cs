using System.Globalization;

namespace exercicioHerancaPolimorfismo.Models {
    class ImportedProduct : Product {
        public double CustomsFee { get; set; }

        public ImportedProduct(string name, double price, double customFee) : base(name, price) {
            CustomsFee = customFee;
        }

        public double TotalPrice() {
            return CustomsFee + Price;
        }

        public override string PriceTag() {
            return $"{base.PriceTag()} (Custums fee: $ {CustomsFee.ToString("F2", CultureInfo.InvariantCulture)})";
        }
    }
}