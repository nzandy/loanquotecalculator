using System;

namespace QuoteCalculator.Models {
	public class LoanOffer {
		public int Amount {get; set;}
		public double Rate {get; set;}
		public string LenderName {get; set;}

		public double GetTotalRepaymentValue(){
			double monthlyInterestRate = Rate / 12;
			var x = 1 - Math.Pow((1 + monthlyInterestRate), -36);
			return ((monthlyInterestRate * Amount) / x) * 36;
		}
		public double GetMonthlyRepaymentValue() {
			return GetTotalRepaymentValue() / 36;
		}
	}
}