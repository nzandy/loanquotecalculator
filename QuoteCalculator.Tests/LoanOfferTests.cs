using System;
using Xunit;
using QuoteCalculator.Models;

namespace QuoteCalculator.Tests {
	public class LoanOfferTests {
		[Fact]
		public void CalculateFutureValue() {
			var loan = new LoanOffer();
			loan.Principle = 1000;
			loan.Rate = 0.07;

			double futureValue = loan.GetTotalRepaymentValue();
		}
		
		[Fact]
		public void CalculateMonthlyRepayment(){
			var loan = new LoanOffer();
			loan.Principle = 1000;
			loan.Rate = 0.07;

			double monthlyRepayment = loan.GetMonthlyRepaymentValue();
		}
	}
}
