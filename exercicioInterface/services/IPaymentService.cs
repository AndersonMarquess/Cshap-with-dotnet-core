using System.Collections.Generic;
using exercicioInterface.Models;

namespace exercicioInterface.Services {
    interface IPaymentService {
        List<Installment> CalculatePayments(Contract contract, int totalInstallments);
    }
}