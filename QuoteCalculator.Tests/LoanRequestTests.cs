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
			Assert.True(request.IsSatisfied(), "The lender has enough funds to satisfy the Request.");
		}

		[Fact]
		public void UnsatisifiedLoanRequest(){
			var lender = new Lender("Bob", 1000, 0.04);
			var request = new LoanRequest(1000, 36);
			request.AddLenderToLoan(lender);
			Assert.False(request.IsSatisfied(), "The lender does not have enough funds to satisfy the Request");
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
			var lender = new Lender("Bob", 1000, 0.07);
			var request = new LoanRequest(1000, 36);
			request.AddLenderToLoan(lender);
			var total = request.GetTotalRepaymentAmount();
			Assert.Equal(1111.58,request.GetTotalRepaymentAmount());
		}

		[Fact]
		public void TotalRepaymentAmountTwoLenders(){
			var lender1 = new Lender("Bob", 500, 0.07);
			var lender2 = new Lender("Anne", 500, 0.07);

			var request = new LoanRequest(1000, 36);
			request.AddLenderToLoan(lender1);
			request.AddLenderToLoan(lender2);
			Assert.Equal(1111.58,request.GetTotalRepaymentAmount());
		}

		[Fact] 
		void MonthlyRepaymentAmount(){
			var lender = new Lender("Bob", 1000, 0.07);
			var request = new LoanRequest(1000, 36);
			request.AddLenderToLoan(lender);
			Assert.Equal(30.88, request.GetMonthlyRepaymentAmount());
		}

		[Fact]
		public void MonthlyRepaymentAmountTwoLenders(){
			var lender1 = new Lender("Bob", 500, 0.07);
			var lender2 = new Lender("Anne", 500, 0.07);

			var request = new LoanRequest(1000, 36);
			request.AddLenderToLoan(lender1);
			request.AddLenderToLoan(lender2);
			Assert.Equal(30.88, request.GetMonthlyRepaymentAmount());
		}
	}
}