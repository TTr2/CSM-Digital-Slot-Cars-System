﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SlotCarsGo_Server.Models
{
    public class RaceType
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Rules { get; set; }
        [Required]
        public string Symbol { get; set; }
    }
}