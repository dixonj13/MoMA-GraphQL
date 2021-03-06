﻿using ProtoBuf;
using System;
using System.Collections.Generic;

namespace GraphQLApi.Models.Api
{
    [ProtoContract]
    public class Artwork
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Title { get; set; }

        [ProtoMember(3)]
        public string Date { get; set; }

        [ProtoMember(4)]
        public string Medium { get; set; }

        [ProtoMember(5)]
        public string DimensionsText { get; set; }

        [ProtoMember(6)]
        public string CreditLine { get; set; }

        [ProtoMember(7)]
        public string AccessionNumber { get; set; }

        [ProtoMember(8)]
        public string Classification { get; set; }

        [ProtoMember(9)]
        public string Department { get; set; }

        [ProtoMember(10)]
        public DateTime DateAcquired { get; set; }

        [ProtoMember(11)]
        public bool Cataloged { get; set; }

        [ProtoMember(12)]
        public string Url { get; set; }

        [ProtoMember(13)]
        public string ThumbnailUrl { get; set; }

        [ProtoMember(14)]
        public Dimensions Dimensions { get; set; }

        [ProtoMember(15)]
        public List<int> ArtistIds { get; set; }
    }
}
