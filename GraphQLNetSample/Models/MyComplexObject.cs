using System.Collections.Generic;

namespace GraphQLNetSample.Models
{
    public class MyComplexObject
    {
        public int Id { get; set; }
        
        public List<Order> Orders { get; set; }
    }
}