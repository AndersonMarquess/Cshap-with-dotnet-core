using System;

namespace exercicioComposicao.models {
    class HourContract {
        public DateTime Date { get; set; }
        public double ValeuPerHour { get; set; }
        public int Hours { get; set; }

        public double TotalValue() {
            return ValeuPerHour * Hours;
        }
    }
}