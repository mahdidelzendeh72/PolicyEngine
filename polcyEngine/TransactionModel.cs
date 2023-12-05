namespace polcyEngine
{
    public enum MyEnum
    {
        None,
        bank,
        credit
    }
    public class TransactionModel
    {
        public string RecordId { get; set; }
        public long InvoiceId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public MyEnum MyEnum { get; set; }
        public bool IsCharter { get; set; }
        public string ProviderName { get; set; }
    }
    public class PaymentModel
    {
        public string RecordId { get; set; }
        public decimal BankAmount { get; set; }
    }
}
