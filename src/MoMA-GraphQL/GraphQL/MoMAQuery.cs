using GraphQL.Types;
using MoMAGraphQL.Data.Repositories;
using MoMAGraphQL.GraphQL.Types;

namespace MoMAGraphQL.GraphQL
{
    public class MoMAQuery : ObjectGraphType<object>
    {
        public MoMAQuery() { }

        public MoMAQuery(IArtistRepository artistRepository)
        {
            Name = "Query";

            Field<ArtistType>(
                "Artist",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "The id of the artist." }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("Id");
                    var artist = artistRepository.Get(id).Result;
                    return artist;
                }
            );

            Field<ListGraphType<ArtistType>>(
                "Artists",
                resolve: context =>
                {
                    var artists = artistRepository.GetAll().Result;
                    return artists;
                }
            );
        }
    }
}
