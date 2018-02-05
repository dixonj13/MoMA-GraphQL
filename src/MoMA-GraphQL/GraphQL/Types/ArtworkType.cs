using GraphQL.Types;
using MoMAGraphQL.Models.Api;
using System;

namespace MoMAGraphQL.GraphQL.Types
{
    public class ArtworkType : ObjectGraphType<Artwork>
    {
        public ArtworkType()
        {
            Name = "Artwork";

            Description = "An item in the Museum of Modern Art (MoMA) collection.";

            Field("id", a => a.Id).Description("The unique id of the item.");

            Field("title", a => a.Title).Description("The title of the item.");

            Field("date", a => a.Date, nullable: true).Description("The date of creation (no standard format).");

            Field("medium", a => a.Medium, nullable: true).Description("The artistic medium of the item.");

            Field("dimensionString", a => a.DimensionsText, nullable: true).Description("The dimensions of the item as a string (no standard format).");

            Field("creditline", a => a.CreditLine, nullable: true).Description("Recognition to the source of the item.");

            Field("accessionNumber", a => a.AccessionNumber).Description("Number assigned to the item at the time of acquisition.");

            Field("classification", a => a.Classification).Description("Category that the item belongs to.");

            Field("department", a => a.Department).Description("Department responsible for curating the item.");

            Field("dateAcquired", a => a.DateAcquired).Description("Date the item was acquired.");

            Field("cataloged", a => a.Cataloged).Description("Whether the item has been cataloged.");

            Field("url", a => a.Url, nullable: true).Description("The URL of the item on MoMA's website.");

            Field("thumbUrl", a => a.ThumbnailUrl, nullable: true).Description("The URL of the item's thumbnail on MoMA's website.");

            Field<DimensionsType>(
                "dimensions",
                "The dimensions of the item.",
                arguments: new QueryArguments(
                    new QueryArgument<UnitLengthType> { Name = "unit", Description = "The unit of length." }
                ),
                resolve: context =>
                {
                    if (context.HasArgument("unit"))
                    {
                        var unit = context.GetArgument<string>("unit");
                        if (unit == "cm")
                        {
                            return context.Source.Dimensions;
                        }
                        else if (unit == "in")
                        {
                            var dims = context.Source.Dimensions;
                            return new Dimensions()
                            {
                                Height = (dims.Height != null) ? dims.Height / 2.54F : null,
                                Width = (dims.Width != null) ? dims.Width / 2.54F : null,
                                Depth = (dims.Depth != null) ? dims.Depth / 2.54F : null,
                                Diameter = (dims.Diameter != null) ? dims.Diameter / 2.54F : null
                            };
                        }
                        else
                        {
                            throw new ArgumentException($"Argument {unit} is not a valid unit of length.");
                        }
                    }
                    else
                    {
                        return context.Source.Dimensions;
                    }
                }
            );
        }
    }
}
