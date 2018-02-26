using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1
{
    #region NewMailEventArgs
    // Этап 1: определение типа, хранящего информацию,
    // которая передается получателям уведомления о событии.
    internal sealed class NewMailEventArgs : EventArgs
    {
        public readonly string mailFrom, mailTo, mailSubject;

        public NewMailEventArgs(string from, string to, string subject)
        {
            mailFrom = from;
            mailTo = to;
            mailSubject = subject;
        }

        public string From { get { return mailFrom; } }
        public string To { get { return mailTo; } }
        public string Subject { get { return mailSubject; } }
    }
    #endregion

    #region MailManager
    class MailManager
    {
        public delegate void NewMailEventHandler(object sender, NewMailEventArgs e);

        //Этап 2. Определение члена-события 
        public event NewMailEventHandler NewMail;

        //Этап 3: Определение метода, ответственного за уведомление зарегистрированных объектов о событии
        protected virtual void OnNewMail(object sender, NewMailEventArgs e)
        {
            if (NewMail != null)
            {
                NewMail(sender, e);
            }
        }

        // Этап 4: определение метода, транслирующего входную информацию в желаемое событие
        public void SimulateNewMail(string from, string to, string subject)
        {
            OnNewMail(this, new NewMailEventArgs(from, to, subject));
        }
    }
    #endregion

    #region Listeners
    sealed class Sms
    {
        public Sms(MailManager mail)
        {
            mail.NewMail += SmsMsg;
        }

        //public void Register(MailManager mail)
        //{
        //    mail.NewMail += SmsMsg;
        //}

        //MailManager вызывает этот метод для уведомления
        //объекта Sms о прибытии нового почтового сообщени
        private void SmsMsg(Object sender, NewMailEventArgs eventArgs)
        {
            Console.WriteLine("Smsing mail message:");
            Console.WriteLine("From = {0}, To = {1}, Subject = {2}", eventArgs.From, eventArgs.To, eventArgs.Subject);
        }

        public void Unregister(MailManager mail)
        {
            mail.NewMail -= SmsMsg;
        }
    }

    class Pager
    {
        //public Pager(MailManager mail)
        //{
        //    mail.newMail += PagerMsg;
        //}

        private void PagerMsg(Object sender, NewMailEventArgs eventArgs)
        {
            Console.WriteLine("Paging mail message:");
            Console.WriteLine("From = {0}, To = {1}, Subject = {2}", eventArgs.From, eventArgs.To, eventArgs.Subject);
        }

        public void Unregister(MailManager mail)
        {
            mail.NewMail -= PagerMsg;
        }

        public void Register(MailManager mail)
        {
            mail.NewMail += PagerMsg;
        }
    }
    #endregion

    public static class Program
    {
        public static void Main(string[] args)
        {
            var manager = new MailManager();
            var sms = new Sms(manager);
            var pager = new Pager();
            pager.Register(manager);
            manager.SimulateNewMail("Minsk", "Riga", "Letter");

            Thread.Sleep(1000);

            sms.Unregister(manager);
            Console.WriteLine();
            manager.SimulateNewMail("Warsawa", "Minsk", "SMS");
            Console.ReadKey();
        }
    }
}
