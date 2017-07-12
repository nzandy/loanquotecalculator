using System;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using QuoteCalculator.Repositories;
using QuoteCalculator.Models;

namespace QuoteCalculator.Tests {
	public class CsvLenderRepositoryTests {
		private List<Lender> _lenders;
		private Lender _firstRecord;
		public CsvLenderRepositoryTests() {
			string path = "./TestData/MarketDataForExercise.csv";
			var repo = new CsvLenderRepository(path);
			_lenders = repo.GetLenders().ToList();
			_firstRecord = _lenders.First();
		}

		[Fact]
		public void BadRecordNotIncluded(){
			Assert.False(_lenders.Any(l => l.Name == "MrError"));
		}

		[Fact]
		public void ParseLenders(){
			Assert.Equal(7, _lenders.Count);
		}

		[Fact]
		public void ParseLenderName(){
			Assert.Equal("Bob", _firstRecord.Name);
		}

		[Fact]
		public void ParseLenderRate(){
			Assert.Equal(0.075, _firstRecord.InterestRate);
		}

		[Fact]
		public void ParseLenderAvailableAmount(){
			Assert.Equal(640, _firstRecord.AvailableAmount);
		}

		[Fact]
		public void InvalidFilePathThrowsException(){
			string path = "./InvalidPath/MarketDataForExercise.csv";
			Assert.Throws(typeof(ArgumentException), () => new CsvLenderRepository(path));
		}
	}
}