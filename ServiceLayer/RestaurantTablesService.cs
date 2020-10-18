using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ServiceLayer.IService;

namespace ServiceLayer
{
   public class RestaurantTablesService:IRestaurantTables
    {
        private RestaurantEntities _db;

        public RestaurantTablesService(RestaurantEntities db)
        {
            _db = db;
        }

        public ICollection<RestaurantTable> GetTables()
        {
            return _db.RestaurantTables.ToList();
        }
    }
}
