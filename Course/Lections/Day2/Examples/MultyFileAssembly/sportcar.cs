//csc /t:library /addmodule:auto.netmodule /out:car.dll sportcar.cs
using System;

namespace Car
{
    public class SportCar
    {
        public void InfoSportCar()
        {
            Console.WriteLine("Audi R8");
        }
    }
}