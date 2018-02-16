﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SlotCarsGo_Server.Models
{
    public class DriverResult
    {
        public int Id { get; set; }

        [Required]
        public int Position { get; set; }
        [Required]
        public int Laps { get; set; }
        [Required]
        public bool Finished { get; set; }
        [Required]
        public float Fuel { get; set; }
        [Required]
        public TimeSpan TotalTime { get; set; }
        [Required]
        public TimeSpan TimeOffPace { get; set; }
        [Required]
        public TimeSpan BestLapTime { get; set; }
        [Required]
        public int ControllerNumber { get; set; }

        // Foreign Key
        [Required]
        public int ApplicationUserId { get; set; }
        // Navigation property
        public ApplicationUser ApplicationUser { get; set; }

        // Foreign key
        [Required]
        public int SessionId { get; set; }
        // Navigation property
        public RaceSession Session { get; set; }

        // Foreign key
        [Required]
        public int CarId { get; set; }
        // Navigation property
        public Car Car { get; set; }
    }
}
