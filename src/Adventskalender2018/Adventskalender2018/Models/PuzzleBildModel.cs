﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventskalender2018.Models
{
    public class PuzzleBildModel
    {
        [JsonProperty(PropertyName = "tag")]
        public int Tag { get; set; }

        [JsonProperty(PropertyName = "bild")]
        public string Bild { get; set; }
    }
}