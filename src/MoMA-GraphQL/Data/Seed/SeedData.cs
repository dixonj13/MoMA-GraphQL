using MoMAGraphQL.Models.Api;
using StackExchange.Redis.Extensions.Core;
using System;
using System.Collections.Generic;

namespace MoMAGraphQL.Data.Seed
{
    public static class SeedData
    {
        public static void EnsureRedisSeed(this ICacheClient cache)
        {
            cache.HashSet(
                "artist",
                new Dictionary<string, Artist>()
                {
                    {
                        "0", new Artist()
                        {
                            Id = 0,
                            Name = "Laura McGinn",
                            Bio = "Copenhagen, Denmark, 1989.",
                            Nationality = "Danish",
                            Gender = "Female",
                            Birth = 1989,
                            Death = 0,
                            WikiQID = "Q93923123",
                            ULAN = "E921K4BDDA",
                            ArtworkIds = new List<int>() { 0, 2 }
                        }
                    },
                    {
                        "1", new Artist()
                        {
                            Id = 1,
                            Name = "Pablo Picasso",
                            Bio = "Born Málaga, Spain, 1881.",
                            Nationality = "Spanish",
                            Gender = "Male",
                            Birth = 1881,
                            Death = 1973,
                            WikiQID = "Q49832371",
                            ULAN = "F93JKXX97",
                            ArtworkIds = new List<int>() { 1 }
                        }
                    }
                }
            );

            cache.HashSet(
                "artwork",
                new Dictionary<string, Artwork>()
                {
                    {
                        "0", new Artwork()
                        {
                            Id = 0,
                            Title = "Orange Sound",
                            Date = "1999",
                            Medium = "Watercolor and colored ink on paper",
                            DimensionsText = "30 x 22\" (76.2 x 55.9 cm)",
                            CreditLine = "Mrs. Gianluigi Gabetti Purchase Fund",
                            AccessionNumber = "1417.2000.3",
                            Classification = "Architecture",
                            Department = "Architecture & Design",
                            DateAcquired = new DateTime(2000, 12, 11),
                            Cataloged = true,
                            Url = "http://www.moma.org/collection/works/947",
                            ThumbnailUrl = "http://www.moma.org/media/W1siZiIsIjU5ODQzIl0sWyJwIiwiY29udmVydCIsIi1yZXNpemUgMzAweDMwMFx1MDAzZSJdXQ.jpg?sha=d857b0f50a166abb",
                            Dimensions = new Dimensions()
                            {
                                Height = 76.2002F,
                                Width = 55.8801F,
                            },
                            ArtistIds = new List<int>() { 0 }
                        }
                    },
                    {
                        "1", new Artwork()
                        {
                            Id = 1,
                            Title = "Villa Snellman, Djursholm, Sweden, Elevation of garden facade, sketch",
                            Date = "n.d.",
                            Medium = "Graphite and crayon on tracing paper mounted on board",
                            DimensionsText = null,
                            CreditLine = "Gift of Mr. and Mrs. Edward Larrabee Barnes, Roblee McCarthy, Jr., Jeffrey P. Klein Purchase Fund, and purchase",
                            AccessionNumber = "33.1990",
                            Classification = "Architecture",
                            Department = "Architecture & Design",
                            DateAcquired = new DateTime(1990, 1, 17),
                            Cataloged = false,
                            Url = null,
                            ThumbnailUrl = null,
                            Dimensions = new Dimensions()
                            {
                                Height = 23.2F,
                                Width = 34.9F
                            },
                            ArtistIds = new List<int>() { 1 }
                        }
                    },
                    {
                        "2", new Artwork()
                        {
                            Id = 2,
                            Title = "Albert Langen-Verlag München",
                            Date = "c. 1925",
                            Medium = "Letterpress",
                            DimensionsText = "8 15/16 x 7 1/8\" (22.7 x 18.1 cm)",
                            CreditLine = "Jan Tschichold Collection, Gift of Philip Johnson",
                            AccessionNumber = "760.1999",
                            Classification = "Design",
                            Department = "Architecture & Design",
                            DateAcquired = new DateTime(1999, 12, 10),
                            Cataloged = true,
                            Url = "http://www.moma.org/collection/works/8069",
                            ThumbnailUrl = "http://www.moma.org/media/W1siZiIsIjk2MzIiXSxbInAiLCJjb252ZXJ0IiwiLXJlc2l6ZSAzMDB4MzAwXHUwMDNlIl1d.jpg?sha=64fb11a597df2722",
                            Dimensions = new Dimensions()
                            {
                                Height = 22.7F,
                                Width = 18.1F,
                            },
                            ArtistIds = new List<int>() { 0 }
                        }
                    }
                }
            );
        }
    }
}
