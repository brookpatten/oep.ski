using System;

namespace Amphibian.Oep.Api.Models
{
    public enum ObservationCategory
    {
        SkiPerformance,
        BodyIndication,
        TurnCharacteristic,
        Equipment,
        Terrain,
        Skier
    }
    public enum SkiPerformance
    {
        Tipping,
        Twisting,
        Bending
    }
    public enum TurnPhase
    {
        Initation,
        Shaping,
        Finish
    }
    public class Observation
    {
        int Id { get; set; }
        public ObservationCategory Category { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public SkiPerformance? SkiPerformance { get; set; }
        public TurnPhase? TurnPhase { get; set; }
        public SnowSport SnowSport { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AcceptedAt { get; set; }
    }
}
