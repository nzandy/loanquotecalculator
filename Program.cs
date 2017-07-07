using System;
using System.Collections.Generic;
using QuoteCalculator.Repositories;
using QuoteCalculator.Models;

namespace QuoteCalculator {
	public class Program {
		private static void Main(string[] args) {
			string filePath = args[0];
			int amountRequested = int.Parse(args[1]);
			Console.WriteLine("Hello World!");
			var loanRepo = new CsvLenderRepository(filePath);
			IEnumerable<AvailableLender> lenders = loanRepo.GetLenders();
		}
	}
}
