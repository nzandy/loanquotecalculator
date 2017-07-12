using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QuoteCalculator.Models;
using QuoteCalculator.Repositories;

namespace QuoteCalculator.Utilities {

	/// <summary>
	/// Responsible for taking requests for loans from prospective borrowers and creating a loan from the
	/// available list of Zopa lenders. We attempt to find the lowest rate possible for the borrower.
	/// </summary>
	public class LoanFinderService {
		private ILenderRepository _lenderRepo;
		public const int MINIMUM_LOAN_AMOUNT = 1000;
		public const int MAXIMUM_LOAN_AMOUNT = 15000;
		public const int INCREMENT_AMOUNT = 100;
		private const int LOAN_TERM_MONTHS = 36;
		public LoanFinderService(ILenderRepository lenderRepo){
			_lenderRepo = lenderRepo;
		}

		public LoanRequest FindBestRate(int loanValue){
			CheckAmountIsValid(loanValue);
			var request = new LoanRequest(loanValue, LOAN_TERM_MONTHS);
			// Get available lenders and sort by best interest rate.
			List<Lender> availableLenders = _lenderRepo.GetLenders()
				.OrderBy(l => l.InterestRate).ToList();
			
			// Iterate over all lenders until we can satisfy the request (or until we have no more lenders).
			foreach (var lender in availableLenders){
				if (request.IsSatisfied()) return request;

				request.AddLenderToLoan(lender);
			}
			return request;
		}

		private void CheckAmountIsValid(int amount){
			if (amount % INCREMENT_AMOUNT != 0){
				throw new ArgumentException(string.Format("Loans must be a multiple of 100 (Your value: {0})", amount));
			} else if (amount < MINIMUM_LOAN_AMOUNT || amount > MAXIMUM_LOAN_AMOUNT){
				throw new ArgumentOutOfRangeException(string.Format("Loans must be between 1000 and 15000 (Your value: {0})", amount));
			} 
		}
	}
}