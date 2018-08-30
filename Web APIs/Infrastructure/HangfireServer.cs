using Autofac;
using Hangfire;
using System.Diagnostics;
namespace Z2data.Web.APIs.Infrastructure
{
    public class HangfireServer
    {
        private static BackgroundJobServer _backgroundJobServer;

        public static void Start(IContainer container)
        {
            GlobalConfiguration.Configuration.UseAutofacActivator(container);
            JobStorage.Current = new Hangfire.SqlServer.SqlServerStorage("HangfireEntities");
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute
            {
                Attempts = 5,
                OnAttemptsExceeded = AttemptsExceededAction.Delete
            });

            _backgroundJobServer = new BackgroundJobServer();

            // synchronization background job
            SynchronizationConfiguration configs = new SynchronizationConfiguration();
            //BackgroundJob.Enqueue<IBusinessUnitMigration>(m => m.MigrateBusinessUnits());
            RecurringJob.AddOrUpdate(() => Debug.WriteLine("Easy!"), Cron.Minutely);

            //RecurringJob.AddOrUpdate<IOrganizationService>(HangfieEnum.BusinessUnits.ToString(),
            //    o => o.GetBusinessUnits(), Cron.Minutely);
        }

        public static void Dispose()
        {
            _backgroundJobServer.Dispose();
        }

        public enum HangfieEnum
        {
            BusinessUnits,
            Specialities
        }
    }
}