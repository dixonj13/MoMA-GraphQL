using GraphQL.Types;
using System;

namespace GraphQLApi.GraphQL
{
    public class MoMASchema : Schema
    {
        public MoMASchema(Func<Type, GraphType> resolver) : base(resolver)
        {
            Query = (MoMAQuery)resolver(typeof(MoMAQuery));
        }
    }
}
