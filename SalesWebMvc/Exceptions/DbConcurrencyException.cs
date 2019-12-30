using System;

namespace SalesWebMvc.Exceptions {
    public class DbConcurrencyException : ApplicationException {

        public DbConcurrencyException(string message) : base(message) { }
    }
}