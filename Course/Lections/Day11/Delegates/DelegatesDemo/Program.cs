using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace DelegatesDemo
{
    internal delegate void Feedback(int value);

    class Program
    {
        static void Main(string[] args)
        {
            Feedback f = null;
           // f.Invoke(67);
            DelegateIntro.Go();
            Console.ReadLine();
        }
    }

    internal sealed class DelegateIntro
    {
        // Declare a delegate type; instances refer to a method that
        // takes an Int32 parameter and returns void.

        internal delegate void Feedback(Int32 value);

        public static void Go()
        {
            StaticDelegateDemo();
            InstanceDelegateDemo();
            ChainDelegateDemo1(new DelegateIntro());
            ChainDelegateDemo2(new DelegateIntro());
        }

        private static void StaticDelegateDemo()
        {
            Console.WriteLine("----- Static Delegate Demo -----");
            Counter(1, 3, null);
            Counter(1, 3, new Feedback(DelegateIntro.FeedbackToConsole));
            Counter(1, 3, new Feedback(FeedbackToMsgBox)); // "Program." is optional
            Console.WriteLine();
        }

        private static void InstanceDelegateDemo()
        {
            Console.WriteLine("----- Instance Delegate Demo -----");
            DelegateIntro di = new DelegateIntro();
            Counter(1, 3, new Feedback(di.FeedbackToFile));

            Console.WriteLine();
        }

        private static void ChainDelegateDemo1(DelegateIntro di)
        {
            Console.WriteLine("----- Chain Delegate Demo 1 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(FeedbackToMsgBox);
            Feedback fb3 = new Feedback(di.FeedbackToFile);

            Feedback fbChain = null;
            fbChain = (Feedback)Delegate.Combine(fbChain, fb1);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb2);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb3);
            Counter(1, 2, fbChain);

            Console.WriteLine();
            fbChain = (Feedback)Delegate.Remove(fbChain, new Feedback(FeedbackToMsgBox));
            Counter(1, 2, fbChain);
        }

        private static void ChainDelegateDemo2(DelegateIntro di)
        {
            Console.WriteLine("----- Chain Delegate Demo 2 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(FeedbackToMsgBox);
            Feedback fb3 = new Feedback(di.FeedbackToFile);

            Feedback fbChain = null;
            fbChain += FeedbackToConsole;
            fbChain += FeedbackToMsgBox;
            fbChain += di.FeedbackToFile;
            
            fbChain += fb2;
            fbChain += fb3;
            Counter(1, 2, fbChain);

            Console.WriteLine();
            fbChain -= FeedbackToMsgBox;
            Counter(1, 2, fbChain);
        }

        private static void Counter(Int32 from, Int32 to, Feedback fb)
        {
            for (Int32 val = from; val <= to; val++)
            {
                if (fb != null) fb(val);
            }
        }

        private static void FeedbackToConsole(Int32 value)
        {
            Console.WriteLine("Item=" + value);
        }

        private static void FeedbackToMsgBox(Int32 value)
        {
            MessageBox.Show("Item=" + value);
        }

        private void FeedbackToFile(Int32 value)
        {
            StreamWriter sw = new StreamWriter("Status.txt", true);
            sw.WriteLine("Item=" + value);
            sw.Close();
        }
    }
}