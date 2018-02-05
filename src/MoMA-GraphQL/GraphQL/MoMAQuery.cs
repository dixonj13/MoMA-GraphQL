using GraphQL.Types;
using MoMAGraphQL.Data.Repositories;
using MoMAGraphQL.GraphQL.Types;
using System.Collections.Generic;

namespace MoMAGraphQL.GraphQL
{
    public class MoMAQuery : ObjectGraphType<object>
    {
        public MoMAQuery() { }

        public MoMAQuery(IArtistRepository artistData, IArtworkRepository artworkData)
        {
            Name = "Query";

            Field<ListGraphType<ArtistType>>(
                "artists",
                arguments: new QueryArguments(
                    new QueryArgument<ListGraphType<IntGraphType>> { Name = "ids", Description = "The ids of the artists." }
                ),
                resolve: context =>
                {
                    var ids = context.GetArgument<List<int>>("ids");
                    if (ids.Count > 0)
                        return artistData.Get(ids).Result;
                    else
                        return artistData.GetAll().Result;
                }
            );

            Field<ListGraphType<ArtworkType>>(
                "artwork",
                arguments: new QueryArguments(
                    new QueryArgument<ListGraphType<IntGraphType>> { Name = "ids", Description = "The ids of the works." }
                ),
                resolve: context =>
                {
                    var ids = context.GetArgument<List<int>>("ids");
                    if (ids.Count > 0)
                        return artworkData.Get(ids).Result;
                    else
                        return artworkData.GetAll().Result;
                }
            );
        }
    }
}
