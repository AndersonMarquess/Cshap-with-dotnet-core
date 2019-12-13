using enumeracoes.models;

namespace enumeracoes {
    class Program {
        static void Main(string[] args) {
            var pedido = new Order { Id = 1 };
            pedido.PrintState();
            pedido.ChangeStatus("processing");
            pedido.PrintState();
        }
    }
}
