using ProtoBuf;

namespace GraphQLApi.Models.Api
{
    [ProtoContract]
    public class Dimensions
    {
        [ProtoMember(1)]
        public float? Height { get; set; }

        [ProtoMember(2)]
        public float? Width { get; set; }

        [ProtoMember(3)]
        public float? Depth { get; set; }

        [ProtoMember(4)]
        public float? Diameter { get; set; }

        public Dimensions ConvertToInches()
        {
            return new Dimensions()
            {
                Height = (Height != null) ? Height / 2.54F : null,
                Width = (Width != null) ? Width / 2.54F : null,
                Depth = (Depth != null) ? Depth / 2.54F : null,
                Diameter = (Diameter != null) ? Diameter / 2.54F : null
            };
        }
    }
}
