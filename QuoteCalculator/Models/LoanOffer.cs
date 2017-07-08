using System;

namespace QuoteCalculator.Models {
	public class LoanOffer {
		private const int LOAN_TERM_MONTHS = 36;
		public int Principle {get; set;}
		public double Rate {get; set;}
		public string LenderName {get; set;}

		public double GetTotalRepaymentValue(){
			double monthlyInterestRate = Rate / 12;
			var x = 1 - Math.Pow((1 + monthlyInterestRate), -LOAN_TERM_MONTHS);
			return ((monthlyInterestRate * Principle) / x) * LOAN_TERM_MONTHS;
		}
		public double GetMonthlyRepaymentValue() {
			return GetTotalRepaymentValue() / LOAN_TERM_MONTHS;
		}
	}
}