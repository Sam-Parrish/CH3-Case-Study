﻿using CS_1.Models.DomainModels;

namespace CS_1.Models.ViewModels
{
    public class IncidentViewModel
    {
        public Incident Incident { get; set; } = null!;

        public IEnumerable<Incident> Incidents { get; set; } = null!;
    }
}
