using System;

namespace QuoteCalculator.Models {

	/// <summary>
	/// Represents a lender registered with Zopa.
	/// </summary>	
	public class Lender {
		public Lender(string name, int amount, double rate){
			Name = name;
			AvailableAmount = amount;
			InterestRate = rate;
		}
		public string Name {get; set;}
		public int AvailableAmount {get; set;}
		public double InterestRate {get; set;}
	}
}