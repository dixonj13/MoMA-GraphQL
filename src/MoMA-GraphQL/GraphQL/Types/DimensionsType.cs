using GraphQL.Types;
using MoMAGraphQL.Models.Api;

namespace MoMAGraphQL.GraphQL.Types
{
    public class DimensionsType : ObjectGraphType<Dimensions>
    {
        public DimensionsType()
        {
            Name = "Dimensions";

            Description = "The dimensions of a piece of artwork.";

            Field("depth", d => d.Depth, nullable: true).Description("The depth of the item.");

            Field("diameter", d => d.Diameter, nullable: true).Description("The diameter of the item.");

            Field("height", d => d.Height, nullable: true).Description("The height of the item.");
            
            Field("width", d => d.Width, nullable: true).Description("The width of the item.");
        }
    }
}
