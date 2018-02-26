using System;
using System.Collections.Generic;

//Наша цель - задавать соответствие интерфейсов и их реализаций.
//Сделаем наше приложение конфигурируемым на клиенте!

//Нам нужен объект, который будет хранить информацию о том, что интерфейсу 
//IReportSender соответствует реализация EmailReportSender и т.д.
//Назовем этот объект ServiceLocator. 
//Связь интерфейса и реализации он будет хранить во внутреннем словаре

namespace IoCSolution.Utility
{
    //Этот класс может быть заменет утилитами:
    //   - StructureMap (AltDotNet)
    //   - Castle Windsor (AltDotNet)
    //   - Unity (Microsoft P&P)
    //   - Ninject (open source)
    //Ручное DI vs IoC оба варианта решают проблему класса с высокой связанностью
    //Вручную - выполнение лишней работы по созданию и наполнению зависимостями
    //Используюя контейнер - досутпны возможности по «автоматическому» или «условному» 
    //наполнению зависимостями, не требующие никаких усилий
    //Время жизни объектов также должно гибко контролироватся, вручную – «лишняя работа»

    // ServiceLocator'у не хватает настроек поведения.

    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, Type> Services = new Dictionary<Type, Type>();

        public static void RegisterService<T>(Type service)
        {
            Services[typeof(T)] = service;
        }

        public static T Resolve<T>()
        {
            //Создает экземпляр типа, объявленного в указанном параметре 
            //универсального типа, с помощью конструктора без параметров
            return (T)Activator.CreateInstance(Services[typeof(T)]);
        }
    }
}
