using System;
using Xunit;
using QuoteCalculator.Models;

namespace QuoteCalculator.Tests {
	public class LoanRequestTests {
		[Fact]
		public void CombinedInterestRate(){
			var lender1 = new Lender();
			lender1.AvailableAmount = 500;
			lender1.InterestRate = 0.05;

			var lender2 = new Lender();
			lender2.AvailableAmount = 500;
			lender2.InterestRate = 0.025;

			var request = new LoanRequest(1000, 36);
			request.AddLenderToLoan(lender1);
			request.AddLenderToLoan(lender2);

			var commbinedRate = request.GetCombinedInterestRate();
		}
	}
}