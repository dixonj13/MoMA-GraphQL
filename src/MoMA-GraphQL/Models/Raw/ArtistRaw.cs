using Newtonsoft.Json;

namespace GraphQLApi.Models.Raw
{
    public class ArtistRaw
    {
        public int ConstituentID { get; set; }

        public string DisplayName { get; set; }

        public string ArtistBio { get; set; }

        public string Nationality { get; set; }

        public string Gender { get; set; }

        public int BeginDate { get; set; }

        public int EndDate { get; set; }

        [JsonProperty(PropertyName = "Wiki QID")]
        public string WikiQID { get; set; }

        public string ULAN { get; set; }
    }
}
