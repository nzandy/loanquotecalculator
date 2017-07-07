using System;
using System.Collections.Generic;
using QuoteCalculator.Repositories;
using QuoteCalculator.Models;
using QuoteCalculator.Utilities;

namespace QuoteCalculator {
	public class Program {
		private static void Main(string[] args) {
			string filePath = args[0];
			int amountRequested = int.Parse(args[1]);
			var loanRepo = new CsvLenderRepository(filePath);
			var loanService = new LoanFinderService(loanRepo);
			var loanRequest = loanService.FindBestRate(amountRequested);

			if (loanRequest.IsSatisfied()) {
				Console.WriteLine("Success, we can service this loan!");
				Console.WriteLine("Initial Loan: {0} Rate: {1}, Monthly Payment: {2}, Total Paid: {3} "
				,amountRequested, loanRequest.GetCombinedInterestRate(), 
				loanRequest.GetMonthlyRepaymentValue(), loanRequest.GetTotalRepaymentValue());
			}
		}
	}
}
