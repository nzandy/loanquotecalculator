using System;
using System.Collections.Generic;
using QuoteCalculator.Repositories;
using QuoteCalculator.Models;
using QuoteCalculator.Utilities;

namespace QuoteCalculator {
	public class Program {
		private static string _lendersFilePath;
		private static int _loanAmount;
		private static void Main(string[] args) {
			ProcessArgs(args);
			var loanRepo = new CsvLenderRepository(_lendersFilePath);
			var loanService = new LoanFinderService(loanRepo);
			LoanRequest request;
			try {
				request = loanService.FindBestRate(_loanAmount);
				request.PrintLoanDetails();
			} catch (Exception ex){
				PrintErrorAndExit(String.Format("Error processing loan request: {0}", ex.Message));
			}
		}

		private static void ProcessArgs(string[] args){
			if (args.Length < 2){
				PrintErrorAndExit("Please provide args in the format: filePath loanAmount");
			}

			if (!int.TryParse(args[1], out _loanAmount)){
				PrintErrorAndExit(
					string.Format("Failed to parse the loan value: {0} to numeric value, please ensure correct format", 
					args[1]));
			}
			_lendersFilePath = args[0];
		}
		private static void PrintErrorAndExit(string message){
			Console.WriteLine(message);
			Environment.Exit(1);
		}
	}
}
