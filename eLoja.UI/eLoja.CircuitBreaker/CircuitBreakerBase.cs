using System;
using System.Threading;

namespace eLoja.CircuitBreaker
{
	public abstract class CircuitBreakerBase
	{
		private readonly ICircuitBreakerStateStore stateStore = new InMemoryState();

		private readonly object halfOpenSyncObject = new object();

		private int numberOfSuccessOperations;
		private bool IsClosed => stateStore.IsClosed;
		private bool IsOpen => !stateStore.IsClosed;

		private TimeSpan OpenToHalfOpenWaitTime { get; set; }

		public CircuitBreakerBase() : this(new TimeSpan(0, 0, 30)) { }

		public CircuitBreakerBase(TimeSpan openToHalfOpenWaitTime)
		{
			OpenToHalfOpenWaitTime = openToHalfOpenWaitTime;
		}

		protected void ExecuteAction(Action action)
		{
			if (IsOpen)
				if (stateStore.LastStateChangedDateUtc.Add(OpenToHalfOpenWaitTime) < DateTime.UtcNow)
					TryExecuteAction(action);
				else
					throw new CircuitBreakerOpenException(stateStore.LastException);
			else
				ExecuteActionOnClosedState(action);
		}

		private void ExecuteActionOnClosedState(Action action)
		{
			try
			{
				action();
			}
			catch (Exception ex)
			{
				numberOfSuccessOperations = 0;
				TrackException(ex);
			}
		}

		private void TryExecuteAction(Action action)
		{
			bool lockTacken = false;
			try
			{
				Monitor.TryEnter(halfOpenSyncObject, ref lockTacken);

				if (lockTacken)
				{
					stateStore.HalfOpen();

					action();

					numberOfSuccessOperations++;

					if (numberOfSuccessOperations >= stateStore.TresholdSuccessOperations)
						stateStore.Reset(); 
				}
			}
			catch (Exception ex)
			{
				TrackException(ex);
			}
			finally
			{
				if (lockTacken)
					Monitor.Exit(halfOpenSyncObject);
			}
		}

		private void TrackException(Exception ex)
		{
			stateStore.Trip(ex);
			throw new CircuitBreakerOpenException(ex);
		}
	}
}
