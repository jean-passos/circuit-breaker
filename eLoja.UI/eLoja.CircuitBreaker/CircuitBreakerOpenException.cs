using System;

namespace eLoja.CircuitBreaker
{
	public class CircuitBreakerOpenException : Exception
	{
		public CircuitBreakerOpenException(Exception ex) : base(ex.Message, ex)
		{

		}
	}
}
