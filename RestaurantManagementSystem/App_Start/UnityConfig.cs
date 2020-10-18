using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using ServiceLayer;
using ServiceLayer.IService;

namespace RestaurantManagementSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
             container.RegisterType<IRestaurantTables,RestaurantTablesService>();
            container.RegisterType<IBooking,BookingService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}