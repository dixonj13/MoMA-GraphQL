using GraphQL.Types;
using MoMAGraphQL.Models.Api;

namespace MoMAGraphQL.GraphQL.Types
{
    public class ArtistType : ObjectGraphType<Artist>
    {
        public ArtistType()
        {
            Name = "Artist";

            Description = "An artist with work in the Museum of Modern Art (MoMA).";

            Field("id", a => a.Id).Description("The unique constituent id of the artist within MoMA.");

            Field("name", a => a.Name).Description("The name of the artist.");

            Field("bio", a => a.Bio, nullable: true).Description("A short biography on the artist.");

            Field("nationality", a => a.Nationality, nullable: true).Description("The nationality of the artist.");

            Field("gender", a => a.Gender, nullable: true).Description("The gender of the artist.");
            
            Field("birth", a => a.Birth).Description("The birth year of the artist.");

            Field("death", a => a.Death).Description("The year the artist died, if deceased (otherwise zero).");

            Field("wikiQid", a => a.WikiQID, nullable: true).Description("The artist's wikidata id.");

            Field("ulan", a => a.ULAN, nullable: true).Description("The artist's Getty Research Institute Union List of Artists id.");
        }
    }
}
