using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLNetSample.Models;

namespace GraphQLNetSample.Repositories.Interfaces
{
    public interface IOrdersStore
    {
        Task<ILookup<int, Order>> GetOrdersByUserIdAsync(IEnumerable<int> arg);
    }
}