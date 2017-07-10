using System;
using Xunit;
using QuoteCalculator.Models;

namespace QuoteCalculator.Tests {
	public class LoanOfferTests {

		private const int LOAN_1_PRINCIPLE = 1000;
		private const double LOAN_1_RATE = 0.07;
		private const int LOAN_PERIOD_MONTHS = 36;
		[Fact]
		public void CalculateFutureValue() {
			var loan = new LoanOffer(LOAN_PERIOD_MONTHS);
			loan.Principle = LOAN_1_PRINCIPLE;
			loan.Rate = LOAN_1_RATE;

			double totalRepayment = loan.GetTotalRepaymentValue();
			Assert.Equal(1111.58, totalRepayment);
		}
		
		[Fact]
		public void CalculateMonthlyRepayment(){
			var loan = new LoanOffer(LOAN_PERIOD_MONTHS);
			loan.Principle = LOAN_1_PRINCIPLE;
			loan.Rate = LOAN_1_RATE;

			double monthlyRepayment = loan.GetMonthlyRepaymentValue();
			Assert.Equal(30.88, monthlyRepayment);

		}
	}
}
