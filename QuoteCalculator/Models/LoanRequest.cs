using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoteCalculator.Models {
	public class LoanRequest {
		private List<LoanOffer> _loanOffers {get; set;}
		private int _loanTermMonths {get; set;}
		public LoanRequest (int principle, int loanTermMonths){
			Principle = principle;
			_loanOffers = new List<LoanOffer>();
			_loanTermMonths = loanTermMonths;
		}
		public int Principle {get; set;}

		public double GetTotalRepaymentAmount(){
			return _loanOffers.Sum(l => l.GetTotalRepaymentValue());
		}
		public double GetMonthlyRepaymentAmount() {
			return _loanOffers.Sum(l => l.GetMonthlyRepaymentValue());
		}
		public double GetCombinedInterestRate() { 
			double combinedInterestRate = 0;
			foreach (LoanOffer loan in _loanOffers){
				combinedInterestRate += (loan.Principle / (double) Principle) * loan.Rate;
			}
			return Math.Round(combinedInterestRate, 2);
		}
		public bool IsSatisfied(){
			if (GetCurrentSatisfiedAmount() == Principle) return true;
			return false;
		}
		public void PrintLoanDetails(){
			if (IsSatisfied()) {
				Console.WriteLine("Requested amount: £{0}", Principle);
				Console.WriteLine("Rate: {0}%", GetCombinedInterestRate() * 100);
				Console.WriteLine("Monthly repayment: £{0}", GetMonthlyRepaymentAmount());
				Console.WriteLine("Total Repayment: £{0}", GetTotalRepaymentAmount());
			} else{
				Console.WriteLine("Our lenders are currently unavailable to service your loan.");
				Console.WriteLine("Please try again later, or contact our Customer Service team.");
			}
		}

		public void AddLenderToLoan(Lender lender){
			int requiredAmount = Principle - GetCurrentSatisfiedAmount();
			var newOffer = new LoanOffer(_loanTermMonths){
				LenderName = lender.Name,
				Rate = lender.InterestRate
			};

			// If we can satisfy the remainder of this loan, do so.
			 if (lender.AvailableAmount >= requiredAmount){
				newOffer.Principle = requiredAmount;
			 } 
			 // Add all available money from this lender to loan and continue.
			 else{
				newOffer.Principle = lender.AvailableAmount;
			 }
			_loanOffers.Add(newOffer);
		}
		private int GetCurrentSatisfiedAmount(){
			return _loanOffers.Sum(l => l.Principle);
		}
	}
}