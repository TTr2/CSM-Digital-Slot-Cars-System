﻿using System;
using System.Collections.Generic;

namespace SlotCarsGo_Server.Models.DTO
{
    /// <summary>
    /// Represents a drivers race session result, suitable for displaying in the results
    /// View and for sending to Entity Framework in the server.
    /// </summary>
    public class DriverResultDTO
    {
        public string Id { get; set; }
        public string DriverId { get; set; }
        public int Position { get; set; }
        public string RaceSessionId { get; set; }
        public int ControllerNumber { get; set; }
        public string CarId { get; set; }
        public int Laps { get; set; }
        public bool Finished { get; set; }
        public float Fuel { get; set; }
        public TimeSpan TotalTime { get; set; }
        public TimeSpan TimeOffPace { get; set; }
        public TimeSpan BestLapTime { get; set; }
    }
}
