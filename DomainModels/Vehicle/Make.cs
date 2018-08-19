﻿using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class Make : Text 
    {
        public Make(string value) : base(value)
        {
        }
    }
}
