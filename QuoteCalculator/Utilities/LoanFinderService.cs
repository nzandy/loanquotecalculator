using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QuoteCalculator.Models;
using QuoteCalculator.Repositories;

namespace QuoteCalculator.Utilities {
	public class LoanFinderService {
		private ILenderRepository _lenderRepo;
		public LoanFinderService(ILenderRepository lenderRepo){
			_lenderRepo = lenderRepo;
		}

		public LoanRequest FindBestRate(int loanValue){
			var request = new LoanRequest(loanValue);
			// Get available lenders and sort by best interest rate.
			List<AvailableLender> availableLenders = _lenderRepo.GetLenders()
				.OrderBy(l => l.InterestRate).ToList();
			
			foreach (var lender in availableLenders){
				if (request.IsSatisfied()) return request;

				request.AddLenderToLoan(lender);
			}

			return request;
		}
	}
}