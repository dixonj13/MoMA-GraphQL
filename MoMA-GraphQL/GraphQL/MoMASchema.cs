using GraphQL.Types;
using System;

namespace MoMAGraphQL.GraphQL
{
    public class MoMASchema : Schema
    {
        public MoMASchema(Func<Type, GraphType> resolver) : base(resolver)
        {
            Query = (MoMAQuery)resolver(typeof(MoMAQuery));
        }
    }
}
