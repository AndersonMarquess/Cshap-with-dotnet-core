using System.Collections.Generic;
using System.Linq;
using exercicioComposicao.models.enums;

namespace exercicioComposicao.models {
    class Worker {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public List<HourContract> Contracts { get; private set; }
        public Department Department { get; set; }

        public Worker() {
            Contracts = new List<HourContract>();
        }

        public void AddContract(HourContract contract) {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract) {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month) {
            var filteredContracts = GetContractsInDate(year, month);
            return CalculateIncome(filteredContracts);
        }

        private List<HourContract> GetContractsInDate(int year, int month) {
            return Contracts
                .Where(c => c.Date.Year == year && c.Date.Month == month)
                .ToList();
        }

        private double CalculateIncome(List<HourContract> contracts) {
            return contracts.Sum(c => c.TotalValue()) + BaseSalary;
        }
    }
}