using System;
using exercicioInterface.Models;

namespace exercicioInterface.Services {
    class ContractService : IContractService {

        private IPaymentService _paymentService;

        public ContractService(IPaymentService paymentService) {
            _paymentService = paymentService;
        }

        public Contract CreateContract(int number, DateTime date, double totalValue, int numberOfInstallments) {
            var contract = new Contract(number, date, totalValue);
            return SetCalculatedInstallments(contract, numberOfInstallments);
        }

        public Contract SetCalculatedInstallments(Contract contract, int numberOfInstallments) {
            contract.Installments = _paymentService.CalculatePayments(contract, numberOfInstallments);
            return contract;
        }
    }
}