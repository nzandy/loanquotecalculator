using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoteCalculator.Models {
	public class LoanRequest {
		private int _principle;
		public LoanRequest (int principle){
			_principle = principle;
			LoanOffers = new List<LoanOffer>();
		}
		public List<LoanOffer> LoanOffers {get; set;}

		public double GetTotalRepaymentValue(){
			return LoanOffers.Sum(l => l.GetTotalRepaymentValue());
		}
		public double GetMonthlyRepaymentValue() {
			return LoanOffers.Sum(l => l.GetMonthlyRepaymentValue());
		}
		public double GetCombinedInterestRate() { 
			double combinedInterestRate = 0;
			foreach (LoanOffer loan in LoanOffers){
				combinedInterestRate += (loan.Principle / (double) _principle) * loan.Rate;
			}
			return Math.Round(combinedInterestRate, 2);
		}
		public int GetSatisfiedAmount(){
			return LoanOffers.Sum(l => l.Principle);
		}

		public bool IsSatisfied(){
			if (GetSatisfiedAmount() == _principle) return true;

			return false;
		}

		public void AddLenderToLoan(AvailableLender lender){
			int requiredAmount = _principle - GetSatisfiedAmount();
			var newOffer = new LoanOffer();
			newOffer.LenderName = lender.LenderName;
			newOffer.Rate = lender.InterestRate;
			// If we can satisfy the remainder of this loan, do so.
			 if (lender.AvailableAmount >= requiredAmount){
				newOffer.Principle = requiredAmount;
			 } 
			 // Add all available money from this lender to loan and continue.
			 else{
				newOffer.Principle = lender.AvailableAmount;
			 }
			LoanOffers.Add(newOffer);	 
		}
	}
}