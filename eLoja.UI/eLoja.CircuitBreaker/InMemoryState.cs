using System;

namespace eLoja.CircuitBreaker
{
	public class InMemoryState : ICircuitBreakerStateStore
	{
		public CircuitBreakerState State { get; private set; }

		public Exception LastException { get; private set; }

		public DateTime LastStateChangedDateUtc { get; private set; }

		public bool IsClosed { get; private set; }

		public int TresholdSuccessOperations => 5;

		public void HalfOpen()
		{
			ChangeCircuitState(CircuitBreakerState.HalfOpen, false);
		}

		public void Reset()
		{
			ChangeCircuitState(CircuitBreakerState.Closed, true);
		}

		public void Trip(Exception ex)
		{
			ChangeCircuitState(CircuitBreakerState.Open, false);
			LastException = ex;
			LastStateChangedDateUtc = DateTime.UtcNow;
		}

		private void ChangeCircuitState(CircuitBreakerState circuitState, bool isClosed)
		{
			State = circuitState;
			IsClosed = isClosed;
		}

	}
}
