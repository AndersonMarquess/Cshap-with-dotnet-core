using System;
using enumeracoes.models.enums;

namespace enumeracoes.models {
    class Order {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public Order() {
            Moment = DateTime.Now;
            Status = OrderStatus.PendingPayment;
        }

        public void ChangeStatus(string status) {
            Status = Enum.Parse<OrderStatus>(status, true);
        }

        public void PrintState() {
            Console.WriteLine($"Id: {Id} Moment: {Moment} Status: {Status}");
        }
    }
}