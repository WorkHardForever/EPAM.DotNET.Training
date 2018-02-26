using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnominusMethodsAndLambda
{
    delegate int MyDelegate(int number);

    public class Program
    {
        // Create an instance of the delegate type.
        //MyDelegate _myDelegateInstance = null;
        //public void AddAnonymousMethodsToDelegate()
        //{
        //    // Add an anonymous method to the delegate.
        //    // Do not specify any parameters.
        //    _myDelegateInstance += delegate
        //        {
        //            // Perform operation.
        //            return 10;
        //        };
        //    // Add an anonymous method to the delegate.
        //    // Specify parameters; the parameters must match
        //    // the signature of the delegate.
        //    _myDelegateInstance += delegate(int parameter)
        //    {
        //        return parameter;
        //    };
        //    _myDelegateInstance += delegate
        //    {
        //        // Perform operation.
        //        return 10;
        //    };
        //    _myDelegateInstance += delegate(int parameter)
        //    {
        //        return parameter;
        //    };
        //    // Invoke the delegate.
        //    _myDelegateInstance -= delegate(int parameter)
        //    {
        //        return parameter;
        //    };

        //    int returnedValue = _myDelegateInstance(2);
        //    // returnedValue = 10 (as second method is called last).
        //}

        delegate int DelegateTypeCounter();
        static DelegateTypeCounter MakeCounter()
        {
            int counter = 0;
            DelegateTypeCounter delegateInstanceCounter =
                delegate
                         {
                             return ++counter;
                         };

            return delegateInstanceCounter;
        }

        static void Main(string[] args)
        {
            DelegateTypeCounter counter1 = MakeCounter();
            DelegateTypeCounter counter2 = MakeCounter();
            System.Console.WriteLine(counter1());
            System.Console.WriteLine(counter1());
            System.Console.WriteLine(counter2());
            System.Console.WriteLine(counter2());
            System.Console.Read();


            //var pt = new Program();
            //pt.AddAnonymousMethodsToDelegate();
            //MyDelegate myDelegateInstance = null;
            ////замыкание 
            //int external = 1;

            //myDelegateInstance += new MyDelegate(x => x++ * x * external);
            ////если в цепочке делегатов возвращается результат, 
            ////то промежуточные результаты будут потеряны вернется только последний
            ////замыкание 
            //external *= 10;
            ////myDelegateInstance += x => x * x * external;
            //var t = myDelegateInstance(6);// t = ?
        }
    }
}
