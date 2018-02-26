using Task2Logic;
using static Task2Console.Program;

namespace Task2Console
{
    public class Listener2
    {
        #region Public Field
        
        public int Number;

        #endregion

        #region Constructor

        public Listener2(int number)
        {
            Number = number;
        }

        #endregion

        #region Public Method

        public void OnTimerTimeout(object sender, TimeleftEventArgs e)
        {
            ShowMessage($"Listener {Number}: Start timer\n\tSender: {sender}\n\tSeconds: {e.Seconds} timeleft.");
        }

        #endregion
    }
}
