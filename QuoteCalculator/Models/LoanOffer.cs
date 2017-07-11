using System;

namespace QuoteCalculator.Models {
	public class LoanOffer {
		private const int DECIMAL_PLACES_DOLLAR = 2;
		private int _loanTermMonths;
		public LoanOffer(int loanTermMonths){
			_loanTermMonths = loanTermMonths;
		}
		public int Principle {get; set;}
		public double Rate {get; set;}
		public string LenderName {get; set;}
		
		public double GetTotalRepaymentValue(){
			double monthlyInterestRate = Rate / 12;
			var x = 1 - Math.Pow((1 + monthlyInterestRate), -_loanTermMonths);
			return Math.Round(((monthlyInterestRate * Principle) / x) * _loanTermMonths, DECIMAL_PLACES_DOLLAR);
		}
		public double GetMonthlyRepaymentValue() {
			return Math.Round(GetTotalRepaymentValue() / _loanTermMonths, DECIMAL_PLACES_DOLLAR);
		}
	}
}