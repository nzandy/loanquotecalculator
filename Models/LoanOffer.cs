using System;

namespace QuoteCalculator.Models {
	public class LoanOffer {
		public string LenderName {get; set;}
		public int AvailableAmount {get; set;}
		public double InterestRate {get; set;}
	}
}