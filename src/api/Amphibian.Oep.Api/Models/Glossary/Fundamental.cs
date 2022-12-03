namespace Amphibian.Oep.Api.Models
{
    public class Fundamental
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
        public SnowSport SnowSport { get; set; }
    }

    public enum SnowSport
    {
        AlpineSki,
        TelemarkSki,
        Snowboard
    }
}
