using System;
using exercicioInterface.Models;

namespace exercicioInterface.Services {
    interface IContractService {
        Contract CreateContract(int number, DateTime date, double totalValue, int numberOfInstallments);

        Contract SetCalculatedInstallments(Contract contract, int numberOfInstallments);
    }
}