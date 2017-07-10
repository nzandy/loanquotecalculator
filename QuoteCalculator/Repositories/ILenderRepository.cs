using System;
using System.Collections.Generic;
using QuoteCalculator.Models;

namespace QuoteCalculator.Repositories {
	/*
		Methods that deal with fetching available loans from a source.s
	 */
	public interface ILenderRepository{
		IEnumerable<Lender> GetLenders();
	}
}