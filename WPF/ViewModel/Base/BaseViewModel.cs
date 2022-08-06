using PropertyChanged;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WPF
{
	[AddINotifyPropertyChangedInterface]
	/// <summary>
	/// A base view model that fires Property Changed events as needed
	/// </summary>
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		#region Protected Members

		/// <summary>
		/// A global lock for property checks so prevent locking on different instances of expressions.
		/// Considering how fast this check will always be it isn't an issue to globally lock all callers.
		/// </summary>
		protected object mPropertyValueCheckLock = new object();

		#endregion

		#region DispatcherTimer

		public virtual DispatcherTimer DispatcherTimer { get; set; } = new DispatcherTimer { Interval = TimeSpan.Zero, IsEnabled = false };
		public virtual void DispatcherTimer_Tick(object sender, EventArgs e) { }
		public virtual void StartDispatcher() => DispatcherTimer.Start();
		public virtual void StopDispatcher() => DispatcherTimer.Stop();
		protected void SetDispatcherTimerInterval(TimeSpan timeSpan) => DispatcherTimer.Interval = timeSpan;

		#endregion

		#region Constructor

		public BaseViewModel()
		{
			DispatcherTimer.Tick += DispatcherTimer_Tick;
		}

		#endregion

		#region PropertyChanged

		/// <summary>
		/// The event that is fired when any child property changes its value
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

		/// <summary>
		/// Call this to fire a <see cref="PropertyChanged"/> event
		/// </summary>
		/// <param name="name"></param>
		public void OnPropertyChanged(string name)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		#endregion

		#region Command Helpers

		/// <summary>
		/// Runs a command if the updating flag is not set.
		/// If the flag is true (indicating the function is already running) then the action is not run.
		/// If the flag is false (indicating no running function) then the action is run.
		/// Once the action is finished if it was run, then the flag is reset to false
		/// </summary>
		/// <param name="updatingFlag">The boolean property flag defining if the command is already running</param>
		/// <param name="action">The action to run if the command is not already running</param>
		/// <returns></returns>
		protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
		{
			// Lock to ensure single access to check
			lock (mPropertyValueCheckLock)
			{
				// Check if the flag property is true (meaning the function is already running)
				if (updatingFlag.GetPropertyValue())
					return;

				// Set the property flag to true to indicate we are running
				updatingFlag.SetPropertyValue(true);
			}

			try
			{
				// Run the passed in action
				await action();
			}
			finally
			{
				// Set the property flag back to false now it's finished
				updatingFlag.SetPropertyValue(false);
			}
		}

		/// <summary>
		/// Runs a command if the updating flag is not set.
		/// If the flag is true (indicating the function is already running) then the action is not run.
		/// If the flag is false (indicating no running function) then the action is run.
		/// Once the action is finished if it was run, then the flag is reset to false
		/// </summary>
		/// <param name="updatingFlag">The boolean property flag defining if the command is already running</param>
		/// <param name="action">The action to run if the command is not already running</param>
		/// <typeparam name="T">The type the action returns</typeparam>
		/// <returns></returns>
		protected async Task<T> RunCommandAsync<T>(Expression<Func<bool>> updatingFlag, Func<Task<T>> action, T defaultValue = default(T))
		{
			// Lock to ensure single access to check
			lock (mPropertyValueCheckLock)
			{
				// Check if the flag property is true (meaning the function is already running)
				if (updatingFlag.GetPropertyValue())
					return defaultValue;

				// Set the property flag to true to indicate we are running
				updatingFlag.SetPropertyValue(true);
			}

			try
			{
				// Run the passed in action
				return await action();
			}
			finally
			{
				// Set the property flag back to false now it's finished
				updatingFlag.SetPropertyValue(false);
			}
		}

		#endregion
	}
}
