using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoteCalculator.Models {
	public class LoanRequest {
		private int _requestAmount;
		public LoanRequest (int requestAmount){
			_requestAmount = requestAmount;
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
			var total = GetTotalRepaymentValue();
			double power = Math.Pow(total / (double)_requestAmount, (double)1/3);
			return power - 1;
		}
		public int GetSatisfiedAmount(){
			return LoanOffers.Sum(l => l.Amount);
		}

		public bool IsSatisfied(){
			if (GetSatisfiedAmount() == _requestAmount) return true;

			return false;
		}

		public void AddLenderToLoan(AvailableLender lender){
			int requiredAmount = _requestAmount - GetSatisfiedAmount();
			var newOffer = new LoanOffer();
			newOffer.LenderName = lender.LenderName;
			newOffer.Rate = lender.InterestRate;
			// If we can satisfy the remainder of this loan, do so.
			 if (lender.AvailableAmount >= requiredAmount){
				newOffer.Amount = requiredAmount;
			 } 
			 // Add all available money from this lender to loan and continue.
			 else{
				newOffer.Amount = lender.AvailableAmount;
			 }
			LoanOffers.Add(newOffer);	 
		}
	}
}