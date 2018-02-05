using MoMAGraphQL.Models.Api;
using StackExchange.Redis.Extensions.Core;
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
                            ArtworkIds = new List<int>() { 1, 2, 3 }
                        }
                    }
                }
            );
        }
    }
}
