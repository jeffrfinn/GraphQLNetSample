using GraphQL.Types;

namespace GraphQLNetSample.GraphQL.Types.Inputs
{
    public class MyInputType: InputObjectGraphType
    {
        public MyInputType()
        {
            Name = "myInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}