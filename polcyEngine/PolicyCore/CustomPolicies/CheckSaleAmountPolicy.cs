using polcyEngine.PolicyCore.Engine;

namespace polcyEngine
{
    public class CheckSaleAmountPolicy : BasePolicy
    {
        private readonly TransactionModel transaction;
        private readonly PaymentModel payment;

        public override string Definition => $"{nameof(CheckSaleAmountPolicy)}: check payment amount and order amount is the same";
        public CheckSaleAmountPolicy(TransactionModel transaction, PaymentModel payment)
        {
            this.transaction = transaction;
            this.payment = payment;
        }

        public override bool When()
        {
            return transaction is not null &&
                 payment is not null;
        }
        public override PolicyResult Check()
        {
            if (transaction.TotalAmount - transaction.DiscountAmount == payment.BankAmount)
                return PolicyResult.SuccessResult();
            return PolicyResult.FailedResult("you have miss-match in bank and order amount", Definition);
        }
    }
}
