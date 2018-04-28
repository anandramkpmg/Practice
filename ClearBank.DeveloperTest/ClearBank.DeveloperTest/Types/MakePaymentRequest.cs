using System;

namespace ClearBank.DeveloperTest.Types
{
    public class MakePaymentRequest : IPayment
    {
        public string CreditorAccountNumber { get; set; }

        public string DebtorAccountNumber { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentScheme PaymentScheme { get; set; }
    }

    public interface IPayment
    {
        decimal Amount { get; set; }

        PaymentScheme PaymentScheme { get; set; }
    }
}
