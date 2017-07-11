using System;
using System.IO;
using System.Collections.Generic;
using QuoteCalculator.Models;

namespace QuoteCalculator.Repositories {
	/*
		Methods that deal with fetching available lenders from a source.
	 */
	public class CsvLenderRepository : ILenderRepository{
		private string _filePath;

		public CsvLenderRepository(string filePath){
			_filePath = filePath;
		}
		public IEnumerable<Lender> GetLenders(){
			var offers = new List<Lender>();
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
							var offer = new Lender(lenderName, availableAmount, interestRate);
							offers.Add(offer);
							index++;
						} catch(Exception ex){
							Console.WriteLine("Error parsing lender at line: {0}. skipping. Ex:{1}", index, ex.Message);
						}
					}
				} catch (Exception ex){
					Console.WriteLine("Error reading from file, exception: {0}", ex.Message);
				}
			}
			return offers;
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