namespace Amphibian.Oep.Api.Models
{
    public class ResponseObservation
    {
        public int Id { get; set; }
        public int ResponseId { get; set; }
        public int ObservationId { get; set; }
        public int? ResponseCauseId { get; set; }
    }
}
