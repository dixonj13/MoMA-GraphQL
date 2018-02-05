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

            Field(a => a.Id).Description("The unique constituent id of the artist within MoMA.");

            Field(a => a.Name).Description("The name of the artist.");

            Field(a => a.Bio, nullable: true).Description("A short biography on the artist.");

            Field(a => a.Nationality, nullable: true).Description("The nationality of the artist.");

            Field(a => a.Gender, nullable: true).Description("The gender of the artist.");
            
            Field(a => a.Birth).Description("The birth year of the artist.");

            Field(a => a.Death).Description("The year the artist died, if deceased (otherwise zero).");

            Field(a => a.WikiQID, nullable: true).Description("The artist's wikidata identifier.");

            Field(a => a.ULAN).Description("The artist's Getty Research Institute Union List of Artists identifier.");
        }
    }
}
