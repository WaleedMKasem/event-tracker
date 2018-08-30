using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Z2data.Core.Caching;
using Z2data.Core.Data;
using Z2data.Data;
using Z2data.Services.Affected;
using Z2data.Services.Events;
using Z2data.Services.Lookups.Countries;
using Z2data.Services.EventCategories;
using Z2data.Services.Locations;
using Z2data.Services.Lookups.Cities;
using Z2data.Services.Lookups.States;
using Z2data.Services.Uploads;
using Z2data.Core;
using Z2data.Services.EventTypes;
using Z2data.Services.Lookups.AirportTypes;
using Z2data.Services.Lookups.Disasters;
using Z2data.Services.SeportTypes;
using Z2data.Services.DisastersTypes;
using Z2data.Services.Disasters;

namespace Z2data.Web.APIs.Infrastructure
{
    public class DependencyRegistrar
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).AsSelf();
            builder.RegisterGeneric(typeof(MongoDbRepositoryAsync<>)).As(typeof(IMongoRepositoryAsync<>))
                .WithParameter("connection", "MongoDB").InstancePerLifetimeScope();

            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().SingleInstance();

            builder.RegisterType<EventService>().As<IEventService>().InstancePerLifetimeScope();
            builder.RegisterType<CountryService>().As<ICountryService>().InstancePerLifetimeScope();
            builder.RegisterType<StateService>().As<IStateService>().InstancePerLifetimeScope();
            builder.RegisterType<CityService>().As<ICityService>().InstancePerLifetimeScope();
            builder.RegisterType<AffectedLocationService>().As<IAffectedLocationService>().InstancePerLifetimeScope();
            builder.RegisterType<EventCategoryService>().As<IEventCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<EventTypeService>().As<IEventTypeService>().InstancePerLifetimeScope();
            builder.RegisterType<AirportService>().As<IAirportService>().InstancePerLifetimeScope();
            builder.RegisterType<SeaportService>().As<ISeaportService>().InstancePerLifetimeScope();
            builder.RegisterType<AttachmentService>().As<IAttachmentService>().InstancePerLifetimeScope();
            builder.RegisterType<DisasterService>().As<IDisasterService>().InstancePerLifetimeScope();
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();
            builder.RegisterType<AirportService>().As<IAirportService>().InstancePerLifetimeScope();
            builder.RegisterType<AirportTypeService>().As<IAirportTypeService>().InstancePerLifetimeScope();
            builder.RegisterType<SeportTypeService>().As<ISeportTypeService>().InstancePerLifetimeScope();
            builder.RegisterType<SubEventTypeService>().As<ISubEventTypeService>().InstancePerLifetimeScope();
            builder.RegisterType<DisasterHistoryService>().As<IDisasterHistoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ParkService>().As<IParkService>().InstancePerLifetimeScope();
            builder.RegisterType<IndustryService>().As<IIndustryService>().InstancePerLifetimeScope();
            var container = builder.Build();
            return container;
        }
    }
}