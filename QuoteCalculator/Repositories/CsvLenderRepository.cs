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
		public IEnumerable<AvailableLender> GetLenders(){
			var offers = new List<AvailableLender>();
			using (var stream = GetFileStream() ) { 
				try{
					string header = stream.ReadLine(); // Ignore first line.
					while (!stream.EndOfStream) {
						var offer = new AvailableLender();
						string line = stream.ReadLine();
						string[] values = line.Split(',');
						offer.LenderName = values[0];
						offer.InterestRate = Double.Parse(values[1]);
						offer.AvailableAmount = Int16.Parse(values[2]);
						offers.Add(offer);
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