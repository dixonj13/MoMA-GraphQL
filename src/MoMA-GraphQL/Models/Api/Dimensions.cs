using ProtoBuf;

namespace MoMAGraphQL.Models.Api
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
    }
}
