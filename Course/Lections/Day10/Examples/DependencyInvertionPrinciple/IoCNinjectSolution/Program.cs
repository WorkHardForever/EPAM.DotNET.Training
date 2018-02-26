using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IoCNinjectSolution.BuisnessFacade;
using IoCNinjectSolution.Domain;
using IoCNinjectSolution.Infrastructure;
using Ninject;

namespace IoCNinjectSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Description
            //аутсорс – вместо того чтобы создавать объект самим (через new()) 
            //мы запрашиваем его у т.н. IoC-контейнера, то есть у фабрики, которая 
            //умеет грамотно производить объекты
            // IoC контейнеры:
            //   - StructureMap (AltDotNet)
            //   - Castle Windsor (AltDotNet)
            //   - Unity (Microsoft P&P)
            //   - Ninject (open source) 
            #endregion

            #region 1 variant
            ////Первый этап заключается в подготовке Ninject для использования. 
            ////Нужно создать экземпляр Ninject ядра – это объект, который мы будем 
            ////использовать для связи с Ninject и запросом реализаций интерфейса
            //IKernel kernel = new StandardKernel();

            ////Второй этап заключается в создании связи между интерфейсами в нашем приложении
            ////и реализациями классов, с которыми мы хотим работать
            ////Устанавливаем интерфейс, с которым мы хотим работать, в качестве параметра типа для метода
            ////Bind и вызываем метод To для результата, который он возвращает
            //kernel.Bind<IReportSender>().To<SmsReportSender>();
            ////Это выражение говорит Ninject, что когда его попросят реализовать интерфейс IReportSender,
            ////он должен выполнить запрос, создав новый экземпляр класса SmsReportSender
            //kernel.Bind<IReportBuilder>().To<ReportBuilder>();
            ////kernel.Bind<IReporter>().To<Reporter>(); //ToSelf();

            ////Последний этап заключается в реальном использовании Ninject, что мы делаем при помощи метода Get
            ////Создание цепочек зависимостей
            //IReporter reporter = kernel.Get<Reporter>();
            //reporter.SendReports();
            #endregion

            #region 2 variant
            IKernel kernel2 = new StandardKernel(new ConfigModule());
            IReporter reporter = kernel2.Get<Reporter>();
            reporter.SendReports();
            #endregion

        }
    }
}
