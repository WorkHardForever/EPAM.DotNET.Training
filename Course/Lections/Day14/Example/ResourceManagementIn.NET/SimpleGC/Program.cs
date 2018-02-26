using System;
using System.Diagnostics;

namespace SimpleGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("***** Fun with System.GC *****");

            Debug.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));//размер heap
            Debug.WriteLine("This OS has {0} object generations.\n", (GC.MaxGeneration + 1));// количество поколений + 1 т.к. нумерация начинается с нулю 

            var refToMyCar1 = new Car("Zippy", 100);
            var refToMyCar2 = new Car("Zippy", 200);
            Debug.WriteLine(refToMyCar1.ToString());           
            Debug.WriteLine(refToMyCar2.ToString());

            Debug.WriteLine("\nGeneration of refToMyCar1 is: {0}", GC.GetGeneration(refToMyCar1));//позволяет проследить в какое поколение попадает объект
            Debug.WriteLine("\nGeneration of refToMyCar2 is: {0}", GC.GetGeneration(refToMyCar2));//позволяет проследить в какое поколение попадает объект
            
            Debug.WriteLine("\nGarbage Collection is being started in 0");
            GC.Collect(0);// метод который должен запустить сборку мусора в нулевом поколении
          
            Debug.WriteLine("Generation of refToMyCar1 is: {0}", GC.GetGeneration(refToMyCar1));
            Debug.WriteLine("Generation of refToMyCar2 is: {0}", GC.GetGeneration(refToMyCar2));

            // для целей тестирования. 
            var tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
                tonsOfObjects[i] = new object();

            Debug.WriteLine("\nEstimated bytes on heap: {0}", GC.GetTotalMemory(false));//размер heap

            Debug.WriteLine("\nGeneration of tonsOfObjects is: {0}", GC.GetGeneration(tonsOfObjects));//  в какое поколение попал большой объект

            refToMyCar1 = null;
            //перечисление GCCollectionMode(Default,Forced,Optimized)
            Debug.WriteLine("\nGarbage Collection is being started in 0 1");
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            Debug.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Debug.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Debug.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));

            Debug.WriteLine("Generation of refToMyCar2 is: {0}", GC.GetGeneration(refToMyCar2));

            Debug.WriteLine("\nAddMemoryPressure(Int32.MaxValue)");
            GC.AddMemoryPressure(Int32.MaxValue);//оповещает CLR о том, что мы хотим забросить очень большой кусок памяти, 
            //GC.WaitForPendingFinalizers();

            Debug.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Debug.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Debug.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));

            Debug.WriteLine("\nGarbage Collection is being started in 0 1");
            GC.Collect(1, GCCollectionMode.Forced);
          
            Debug.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Debug.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Debug.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));

                     
           // Debug.WriteLine("\nGarbage Collection is being started in 0 1");
           // GC.Collect(1, GCCollectionMode.Forced);
           //// GC.WaitForPendingFinalizers();

           // // Вывод информации о том, сколько раз в отношении 
           // // объектов каждого поколения выполнялась сборка мусора. 
           // Debug.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));
           // Debug.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
           // Debug.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
           // Debug.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));
        }
    }
}
