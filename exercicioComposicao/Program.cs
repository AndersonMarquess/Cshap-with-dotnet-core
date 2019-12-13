using System;
using System.Globalization;
using exercicioComposicao.models;
using exercicioComposicao.models.enums;

namespace exercicioComposicao {
    class Program {
        static void Main(string[] args) {
            var department = GetDepartmentData();
            var worker = GetWorkerData(department);

            Console.Write("How many contracts to this worker? ");
            var numberContracts = int.Parse(Console.ReadLine());

            AddContractsInWorker(numberContracts, worker);

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            var date = Console.ReadLine();
            var month = int.Parse(date.Split("/")[0]);
            var year = int.Parse(date.Split("/")[1]);
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income: {worker.Income(year, month).ToString("F2")}");
        }

        private static void AddContractsInWorker(int numberContracts, Worker worker) {
            for (int i = 1; i <= numberContracts; i++) {
                Console.WriteLine($"Enter #{i} contract data:");
                worker.AddContract(GetContractData());
            }
        }

        private static HourContract GetContractData() {
            Console.Write("Date (DD/MM/YYYY): ");
            var date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Valeu per hour: ");
            var value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Duration (hours): ");
            var hours = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            return new HourContract { Date = date, ValeuPerHour = value, Hours = hours };
        }

        private static Department GetDepartmentData() {
            Console.Write("Enter department's name: ");
            var name = Console.ReadLine();
            return new Department { Name = name };
        }

        private static Worker GetWorkerData(Department department) {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            var level = Enum.Parse<WorkerLevel>(Console.ReadLine(), true);

            Console.Write("Base salary: ");
            var salary = double.Parse(Console.ReadLine(), CultureInfo.InstalledUICulture);

            return new Worker { Name = name, Level = level, BaseSalary = salary, Department = department };
        }
    }
}
