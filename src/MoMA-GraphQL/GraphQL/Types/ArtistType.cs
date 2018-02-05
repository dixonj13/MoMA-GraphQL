using GraphQL.Types;
using MoMAGraphQL.Data.Repositories;
using MoMAGraphQL.Models.Api;

namespace MoMAGraphQL.GraphQL.Types
{
    public class ArtistType : ObjectGraphType<Artist>
    {
        public ArtistType(IArtworkRepository artworkData)
        {
            Name = "Artist";

            Description = "An artist with work in the Museum of Modern Art (MoMA).";

            Field("id", a => a.Id).Description("The unique constituent id of the artist within MoMA.");

            Field<ListGraphType<ArtworkType>>(
                "artwork",
                "All works created by the artist.",
                resolve: context =>
                {
                    var ids = context.Source.ArtworkIds;
                    var artists = artworkData.Get(ids);
                    return artists;
                }
            );

            Field("bio", a => a.Bio, nullable: true).Description("A short biography on the artist.");

            Field("birth", a => a.Birth).Description("The birth year of the artist.");

            Field("death", a => a.Death).Description("The year the artist died, if deceased (otherwise zero).");

            Field("gender", a => a.Gender, nullable: true).Description("The gender of the artist.");

            Field("name", a => a.Name).Description("The name of the artist.");

            Field("nationality", a => a.Nationality, nullable: true).Description("The nationality of the artist.");

            Field("ulan", a => a.ULAN, nullable: true).Description("The artist's Getty Research Institute Union List of Artists id.");

            Field("wikiQid", a => a.WikiQID, nullable: true).Description("The artist's wikidata id.");
        }
    }
}
