using System;

namespace eLoja.CircuitBreaker
{
	public interface ICircuitBreakerStateStore
	{
		CircuitBreakerState State { get; }
		Exception LastException { get; }
		DateTime LastStateChangedDateUtc { get; }
		bool IsClosed { get; }
		int TresholdSuccessOperations { get; }
		void Trip(Exception ex);
		void Reset();
		void HalfOpen();
	}
}
