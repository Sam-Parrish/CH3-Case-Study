namespace CS_1.Models
{
	public class IncidentViewModel
	{
		public Incident Incident { get; set; } = null!;

		public IEnumerable<Incident> Incidents { get; set; } = null!;
	}
}
