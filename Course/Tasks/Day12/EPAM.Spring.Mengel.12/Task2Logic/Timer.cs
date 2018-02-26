using System;
using System.Threading.Tasks;
using static System.Threading.Thread;

namespace Task2Logic
{
    public class Timer
    {
        #region Private Fields

        private bool IsStarted;
        private const int ONE_SECOND_IN_SLEEP = 1000;

        #endregion

        #region Public Method

        public async void RunIfCan(int seconds)
        {
            if (IsStarted == true)
                return;

            await Task.Run(() =>
            {
                Sleep(seconds * ONE_SECOND_IN_SLEEP);
                OnTimeout(this, new TimeleftEventArgs(seconds));
                IsStarted = false;
            });
        }

        #endregion

        #region Protected Method

        protected virtual void OnTimeout(object sender, TimeleftEventArgs e) =>
            Dispatcher?.Invoke(sender, e);

        #endregion

        #region Event
        
        public event EventHandler<TimeleftEventArgs> Dispatcher;

        #endregion
    }
}
