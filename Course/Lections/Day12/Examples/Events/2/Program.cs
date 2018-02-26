using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2
{
    #region NewMailEventArgs
    // Этап 1: определение типа, хранящего информацию,
    // которая передается получателям уведомления о событии.
    public sealed class NewMailEventArgs : EventArgs
    {
        #region fields
        public readonly string mailFrom;
        public readonly string mailTo;
        public readonly string mailSubject;
        #endregion

        #region ctor
        public NewMailEventArgs(string from, string to, string subject)
        {
            mailFrom = from;
            mailTo = to;
            mailSubject = subject;
        }
        #endregion

        #region properties
        public string From { get { return mailFrom; } }
        public string To { get { return mailTo; } }
        public string Subject { get { return mailSubject; } }
        #endregion
    }
    #endregion

    #region MailManager
    public class MailManager
    {
        //Этап 2. Определение члена-события 
        public event EventHandler<NewMailEventArgs> NewMail = delegate { };

        //Этап 3: Определение метода, ответственного за уведомление зарегистрированных объектов о событии
        //(Для изолированного класса метод будет закрытый и невиртуальный)
        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            ////для синхронизации потоков
            ////EventHandler<NewMailEventArgs> temp = newMail;//возможна оптимизация компилятора!
            //EventHandler<NewMailEventArgs> temp = Interlocked.CompareExchange(ref NewMail, null, null);
            ////CompareExchange изменяет ссылку temp на null, если newMail и не трогает ее в противном случае

            //Потокобезопасный вызов события оставлен на усмотрение разработчиков
            if (NewMail != null)
            {
                // может быть вызвано исключение NullReferenceException в том случае,
                // если обработчик был удален из списка уже после проверки
                NewMail(this, e);
            }
        }

        // Этап 4: определение метода, транслирующего входную информацию в желаемое событие
        public void SimulateNewMail(string from, string to, string subject)
        {
            OnNewMail(new NewMailEventArgs(from, to, subject));
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

        //MailManager вызывает этот метод для уведомления
        //объекта Fax о прибытии нового почтового сообщени
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
        public Pager(MailManager mail)
        {
            mail.NewMail += PagerMsg;
        }

        private void PagerMsg(Object sender, NewMailEventArgs eventArgs)
        {
            Console.WriteLine("Paging mail message:");
            Console.WriteLine("From = {0}, To = {1}, Subject = {2}", eventArgs.From, eventArgs.To, eventArgs.Subject);
        }

        public void Unregister(MailManager mail)
        {
            mail.NewMail -= PagerMsg;
        }
    }
    #endregion

    public static class Program
    {
        public static void Main(string[] args)
        {
            var manager = new MailManager();
            var sms = new Sms(manager);
            var pager = new Pager(manager);
            manager.SimulateNewMail("Minsk", "Moskva", "Letter");

            Thread.Sleep(1000);

            sms.Unregister(manager);
            Console.WriteLine();
            manager.SimulateNewMail("Moskva", "Minsk", "SMS");

            Console.ReadKey();
        }
    }
}
