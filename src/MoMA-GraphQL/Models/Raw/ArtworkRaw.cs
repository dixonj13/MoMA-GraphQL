using Newtonsoft.Json;
using System.Collections.Generic;

namespace GraphQLApi.Models.Raw
{
    public class ArtworkRaw
    {
        public int ObjectID { get; set; }

        public string Title { get; set; }

        public List<string> Artist { get; set; }

        public List<string> ConstituentID { get; set; }

        public List<string> ArtistBio { get; set; }

        public List<string> Nationality { get; set; }

        public List<int> BeginDate { get; set; }

        public List<int> EndDate { get; set; }

        public List<string> Gender { get; set; }

        public string Date { get; set; }

        public string Medium { get; set; }

        public string Dimensions { get; set; }

        public string CreditLine { get; set; }

        public string AccessionNumber { get; set; }

        public string Classification { get; set; }

        public string Department { get; set; }

        public string DateAcquired { get; set; }

        public string Cataloged { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "Height (cm)")]
        public float? Height { get; set; }

        [JsonProperty(PropertyName = "Width (cm)")]
        public float? Width { get; set; }

        [JsonProperty(PropertyName = "Depth (cm)")]
        public float? Depth { get; set; }

        [JsonProperty(PropertyName = "Diameter (cm)")]
        public float? Diameter { get; set; }
    }
}
