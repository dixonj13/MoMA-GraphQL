using GraphQL.Types;
using MoMAGraphQL.Data.Repositories;
using MoMAGraphQL.Models.Api;
using System;

namespace MoMAGraphQL.GraphQL.Types
{
    public class ArtworkType : ObjectGraphType<Artwork>
    {
        public ArtworkType(IArtistRepository artistData)
        {
            Name = "Artwork";

            Description = "An item in the Museum of Modern Art (MoMA) collection.";

            Field("id", a => a.Id).Description("The unique id of the item.");

            Field("accessionNumber", a => a.AccessionNumber).Description("Number assigned to the item at the time of acquisition.");

            Field<ListGraphType<ArtistType>>(
                "artists",
                "The artists who created the work.",
                resolve: context =>
                {
                    var ids = context.Source.ArtistIds;
                    var artists = artistData.Get(ids);
                    return artists;
                }
            );

            Field("cataloged", a => a.Cataloged).Description("Whether the item has been cataloged.");

            Field("classification", a => a.Classification).Description("Category that the item belongs to.");

            Field("creditline", a => a.CreditLine, nullable: true).Description("Recognition to the source of the item.");

            Field("date", a => a.Date, nullable: true).Description("The date of creation (no standard format).");

            Field("dateAcquired", a => a.DateAcquired).Description("Date the item was acquired.");

            Field("department", a => a.Department).Description("Department responsible for curating the item.");

            Field<DimensionsType>(
                "dimensions",
                "The dimensions of the item.",
                arguments: new QueryArguments(
                    new QueryArgument<UnitLengthType> { Name = "unit", Description = "The unit of length." }
                ),
                resolve: context =>
                {
                    var unit = context.GetArgument<string>("unit");
                    if (unit != null)
                    {
                        if (unit == "cm")
                            return context.Source.Dimensions;
                        else if (unit == "in")
                            return context.Source.Dimensions.ConvertToInches();
                        else
                            throw new ArgumentException($"Argument {unit} is not a valid unit of length.");
                    }
                    else
                        return context.Source.Dimensions;
                }
            );

            Field("dimensionString", a => a.DimensionsText, nullable: true).Description("The dimensions of the item as a string (no standard format).");

            Field("medium", a => a.Medium, nullable: true).Description("The artistic medium of the item.");

            Field("title", a => a.Title).Description("The title of the item.");

            Field("thumbUrl", a => a.ThumbnailUrl, nullable: true).Description("The URL of the item's thumbnail on MoMA's website.");

            Field("url", a => a.Url, nullable: true).Description("The URL of the item on MoMA's website.");
        }
    }
}
