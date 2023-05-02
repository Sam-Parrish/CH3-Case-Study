namespace CS_1.Models.DomainModels
{
    public class Home
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}