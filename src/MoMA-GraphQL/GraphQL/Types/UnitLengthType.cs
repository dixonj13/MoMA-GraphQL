﻿using GraphQL.Types;

namespace GraphQLApi.GraphQL.Types
{
    public class UnitLengthType : EnumerationGraphType
    {
        public UnitLengthType()
        {
            Name = "UnitLength";

            Description = "Units of length.";

            AddValue("cm", "Centimeters", "cm");
            AddValue("in", "Inches", "in");
        }
    }
}
