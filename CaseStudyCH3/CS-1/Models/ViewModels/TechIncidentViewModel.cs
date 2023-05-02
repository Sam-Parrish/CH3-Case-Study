using CS_1.Models.DomainModels;

namespace CS_1.Models.ViewModels
{
    public class TechIncidentViewModel
    {
        public Technician Technician { get; set; } = null!;
        public Incident Incident { get; set; } = null!;

        public IEnumerable<Incident> Incidents { get; set; } = null!;
    }
}
