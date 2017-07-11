using System;
using Xunit;
using QuoteCalculator.Models;

namespace QuoteCalculator.Tests {
	public class LoanRequestTests {

		[Fact]
		public void SatisfiedLoanRequest(){
			var lender = new Lender("Bob", 1000, 0.04);
			var request = new LoanRequest(1000, 36);
			request.AddLenderToLoan(lender);
			Assert.True(request.IsSatisfied());
		}

		[Fact]
		public void UnsatisifiedLoanRequest(){
			var lender = new Lender("Bob", 1000, 0.04);
			var request = new LoanRequest(1000, 36);
			request.AddLenderToLoan(lender);
			Assert.False(request.IsSatisfied(), "The total amount of request hasn't been satisfied by the lender");
		}

		[Fact]
		public void CombinedInterestRate(){
			var lender1 = new Lender("Bob", 500, 0.05);
			var lender2 = new Lender("Lucy", 500, 0.025);
			var request = new LoanRequest(1000, 36);
			request.AddLenderToLoan(lender1);
			request.AddLenderToLoan(lender2);

			var commbinedRate = request.GetCombinedInterestRate();
			Assert.Equal(0.04, commbinedRate);
		}

		[Fact]
		public void TotalRepaymentAmount(){
			
		}
	}
}