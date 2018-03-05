using ProtoBuf;
using System.Collections.Generic;

namespace GraphQLApi.Models.Api
{
    [ProtoContract]
    public class Artist
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public string Bio { get; set; }

        [ProtoMember(4)]
        public string Nationality { get; set; }

        [ProtoMember(5)]
        public string Gender { get; set; }

        [ProtoMember(6)]
        public int Birth { get; set; }

        [ProtoMember(7)]
        public int Death { get; set; }

        [ProtoMember(8)]
        public string WikiQID { get; set; }

        [ProtoMember(9)]
        public string ULAN { get; set; }

        [ProtoMember(10)]
        public List<int> ArtworkIds { get; set; }
    }
}
