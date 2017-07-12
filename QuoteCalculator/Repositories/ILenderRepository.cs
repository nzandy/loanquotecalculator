using System;
using System.Collections.Generic;
using QuoteCalculator.Models;

namespace QuoteCalculator.Repositories {
	public interface ILenderRepository{
		IEnumerable<Lender> GetLenders();
	}
}