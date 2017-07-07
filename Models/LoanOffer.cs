using System;

namespace QuoteCalculator.Models {
	public class LoanOffer {
		public int Amount {get; set;}
		public double Rate {get; set;}
		public string LenderName {get; set;}

		public double GetTotalRepaymentValue(){
			return Amount * Math.Pow((1 + Rate), 3);
		}
		public double GetMonthlyRepaymentValue() {
			return GetTotalRepaymentValue() / 36;
		}
	}
}