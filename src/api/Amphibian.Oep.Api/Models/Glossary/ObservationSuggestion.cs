namespace Amphibian.Oep.Api.Models
{
    public class ObservationSuggestion
    {
        int Id { get; set; }
        public int IfObservationId { get; set; }
        public int ThenObservationId { get; set; }
    }
}
