using System;
using System.Collections.Generic;
using exercicioInterface.Models;

namespace exercicioInterface.Services {
    class PayPalService : IPaymentService {

        public int _totalInstallment { get; private set; }
        public Contract _contract { get; private set; }

        public List<Installment> CalculatePayments(Contract contract, int totalInstallments) {
            _totalInstallment = totalInstallments;
            _contract = contract;
            return CalculatedInstallments();
        }

        private List<Installment> CalculatedInstallments() {
            var installments = new List<Installment>();
            for (int installmentNumber = 1; installmentNumber <= _totalInstallment; installmentNumber++) {
                installments.Add(GenerateInstallment(installmentNumber));
            }
            return installments;
        }

        private Installment GenerateInstallment(int installmentNumber) {
            var valueWithFee = CalculateAllTax(installmentNumber);
            DateTime dueDate = _contract.Date.AddMonths(installmentNumber);
            return new Installment(dueDate, valueWithFee);
        }

        private double CalculateAllTax(int installmentNumber) {
            var valueWithInterest = CalculateMonthlySimpleInterest(GetMonthBaseValue(), installmentNumber);
            return CalculatePlaymentFee(valueWithInterest);
        }

        private double GetMonthBaseValue() {
            return _contract.TotalValue / _totalInstallment;
        }

        private double CalculateMonthlySimpleInterest(double contractValue, int installmentNumber) {
            var valueWithMonthInterest = contractValue * 0.01;
            contractValue += valueWithMonthInterest * installmentNumber;
            return contractValue;
        }

        private double CalculatePlaymentFee(double amount) {
            var feePercentage = 1.02;
            return amount * feePercentage;
        }
    }
}