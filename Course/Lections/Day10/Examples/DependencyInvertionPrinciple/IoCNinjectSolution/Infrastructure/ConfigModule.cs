using IoCNinjectSolution.BuisnessFacade;
using IoCNinjectSolution.Domain;
using Ninject.Modules;

namespace IoCNinjectSolution.Infrastructure
{
    public class ConfigModule : NinjectModule
    {
        #region Overrides of NinjectModule

        public override void Load()
        {
            this.Bind<IReportSender>().To<SmsReportSender>();
            this.Bind<IReportBuilder>().To<ReportBuilder>();
            //this.Bind<IReporter>().ToSelf();
        }

        #endregion
    }
}
