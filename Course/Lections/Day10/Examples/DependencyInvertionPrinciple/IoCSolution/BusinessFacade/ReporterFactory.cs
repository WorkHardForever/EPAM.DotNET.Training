using IoCSolution.Domain;
using IoCSolution.Utility;

namespace IoCSolution.BusinessFacade
{
    public static class ReporterFactory
    {
        public static IReporter Create()
        {
            return ServiceLocator.Resolve<IReporter>();
        }
    }
}