using System;
using System.IO;
using System.Collections.Generic;
using QuoteCalculator.Models;

namespace QuoteCalculator.Repositories {
	/*
		Methods that deal with fetching / caching available lenders from a CSV file..
	 */
	public class CsvLenderRepository : ILenderRepository{
		private string _filePath;
		private List<Lender> _lenders;

		public CsvLenderRepository(string filePath){
			if (!File.Exists(filePath)){
				throw new ArgumentException(string.Format("File does not exist: {0}", filePath));
			}
			_filePath = filePath;
		}
		public IEnumerable<Lender> GetLenders(){
			// If we have already parsed the CSV, return the collection.
			if (_lenders != null) {
				return _lenders;
			}

			_lenders = new List<Lender>();
			int index = 0;
			using (var stream = GetFileStream() ) { 
				try{
					string header = stream.ReadLine(); // Ignore first line.
					while (!stream.EndOfStream) {
						try {
							string line = stream.ReadLine();
							string[] values = line.Split(',');
							string lenderName = values[0];
							double interestRate = Double.Parse(values[1]);
							int availableAmount = Int16.Parse(values[2]);
							var newLender = new Lender(lenderName, availableAmount, interestRate);
							_lenders.Add(newLender);
							index++;
						} catch(Exception ex){
							Console.WriteLine("Error parsing lender at line: {0}. skipping. Ex:{1}", index, ex.Message);
						}
					}
				} catch (Exception ex){
					Console.WriteLine("Error reading from file, exception: {0}", ex.Message);
				}
			}
			return _lenders;
		}

		private StreamReader GetFileStream(){
			try{
				return File.OpenText(_filePath);
			} catch (Exception ex){
				Console.WriteLine("Error Opening filepath: {0}, message: {1}", _filePath, ex.Message);
				throw;
			}
		}
	}
}