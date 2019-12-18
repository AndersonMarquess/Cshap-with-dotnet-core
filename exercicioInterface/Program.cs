using System;
using System.Globalization;
using exercicioInterface.Services;

namespace exercicioInterface {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installment: ");
            int installment = int.Parse(Console.ReadLine());
            
            var contractService = new ContractService(new PayPalService());
            var contract = contractService.CreateContract(number, date, value, installment);
            contract.Installments.ForEach(c => System.Console.WriteLine(c));
        }
    }
}
