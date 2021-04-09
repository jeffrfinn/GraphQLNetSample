using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLNetSample.Models;
using GraphQLNetSample.Repositories.Interfaces;

namespace GraphQLNetSample.Repositories
{
    public class OrderStore : IOrdersStore
    {
        public async Task<ILookup<int, Order>> GetOrdersByUserIdAsync(IEnumerable<int> arg)
        {
            var orders = new List<Order>
            {
                new Order{Id =1,Description ="Order 1"},
                new Order{Id =2,Description ="Order 2"}
            };

            return orders.ToLookup(x => x.Id);
        }
    }
}