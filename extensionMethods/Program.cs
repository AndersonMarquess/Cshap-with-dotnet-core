using System;

namespace extensionMethods {
    class Program {
        static void Main(string[] args) {
            DateTime date = new DateTime(2019, 12, 18, 16, 30, 01);
            Console.WriteLine(date.ElapsedTime());
        }
    }
}
