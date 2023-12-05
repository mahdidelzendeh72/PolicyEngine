namespace polcyEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var engine = new PolicyEngine();

            engine.AddRangePolicy(GetAllPolicies());

            var result = engine.Run();

            if (!result.Any(p => !p.IsPassed))
            {
                //add to messy transaction
            }
            else
            {
                //add to clean transaction
            }


        }
        public static List<IPolicy> GetAllPolicies()
        {
            var result = new List<IPolicy>();
            var model = new TransactionModel { IsCharter = true, MyEnum = MyEnum.credit, TotalAmount = 90, InvoiceId = 12, ProviderName = "Lamaso", RecordId = "1584", DiscountAmount = 10 };
            var pay = new PaymentModel { BankAmount = 80, RecordId = "58" };
            result.Add(new NotNullOrEmptyStringPolicy(model, nameof(TransactionModel.ProviderName)));
            result.Add(new NotNullOrEmptyStringPolicy(model, nameof(TransactionModel.RecordId)));
            result.Add(new InvalidEnumPolicy<MyEnum>(model, nameof(TransactionModel.MyEnum), MyEnum.None, MyEnum.credit));
            result.Add(new CheckSaleAmountPolicy(model, pay));
            return result;

        }
    }
}
