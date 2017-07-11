using System.Collections.Generic;
using QuoteCalculator.Repositories;
using QuoteCalculator.Models;

namespace QuoteCalculator.Tests.Mocks {
	public class MockLenderRepository : ILenderRepository {
		public IEnumerable<Lender> GetLenders(){
			return new List<Lender>(){
				new Lender("Bob", 640, 0.075),
				new Lender("Jane", 480, 0.069),
				new Lender("Fred", 520, 0.071),
				new Lender("Mary", 170, 0.104),
				new Lender("John", 320, 0.081),
				new Lender("Dave", 140, 0.074),
				new Lender("Angela", 60, 0.071)
			};
		}
	}
}