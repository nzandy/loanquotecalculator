using System;
using Xunit;
using QuoteCalculator.Utilities;
using QuoteCalculator.Models;
using QuoteCalculator.Tests.Mocks;

namespace QuoteCalculator.Tests {
	public class LoanFinderServiceTests {
		private LoanFinderService _loanService;
		public LoanFinderServiceTests(){
			_loanService = new LoanFinderService(new MockLenderRepository());
		}
		
		[Fact]
		public void BestInterestRate(){
			LoanRequest result = _loanService.FindBestRate(1000);
			Assert.Equal(0.07, result.GetCombinedInterestRate());
		}

		[Fact]
		public void LoanAmountCannotBeFulfilled(){
			LoanRequest result = _loanService.FindBestRate(10000);
			Assert.False(result.IsSatisfied());
		}

		[Fact]
		public void ExceedingMaximumRequestAmount(){
			Assert.Throws(typeof(ArgumentOutOfRangeException), () => 
			_loanService.FindBestRate(LoanFinderService.MAXIMUM_LOAN_AMOUNT + 100));
		}

		[Fact]
		public void DoesNotMeetMinimumAmount(){
			Assert.Throws(typeof(ArgumentOutOfRangeException), () => 
			_loanService.FindBestRate(LoanFinderService.MINIMUM_LOAN_AMOUNT - 100));
		}

		[Fact]
		public void IsNotDivisibleByIncrementAmount(){
			Assert.Throws(typeof(ArgumentException), () => 
			_loanService.FindBestRate(LoanFinderService.MINIMUM_LOAN_AMOUNT + LoanFinderService.INCREMENT_AMOUNT + 1));
		}
	}
}