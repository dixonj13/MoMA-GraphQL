using GraphQL.Types;
using MoMAGraphQL.Data.Repositories;
using MoMAGraphQL.GraphQL.Types;

namespace MoMAGraphQL.GraphQL
{
    public class MoMAQuery : ObjectGraphType<object>
    {
        public MoMAQuery() { }

        public MoMAQuery(IArtistRepository artistData, IArtworkRepository artworkData)
        {
            Name = "Query";

            Field<ArtistType>(
                "Artist",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "The id of the artist." }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var artist = artistData.Get(id).Result;
                    return artist;
                }
            );

            Field<ListGraphType<ArtistType>>(
                "Artists",
                resolve: context =>
                {
                    var artists = artistData.GetAll().Result;
                    return artists;
                }
            );

            Field<ArtworkType>(
                "Artwork",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "The id of the artwork." }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var artist = artworkData.Get(id).Result;
                    return artist;
                }
            );

            Field<ListGraphType<ArtistType>>(
                "Artworks",
                resolve: context =>
                {
                    var artworks = artworkData.GetAll().Result;
                    return artworks;
                }
            );
        }
    }
}
