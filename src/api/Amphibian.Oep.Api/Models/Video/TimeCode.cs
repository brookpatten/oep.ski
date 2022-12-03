namespace Amphibian.Oep.Api.Models
{
    public enum TimeCodeType
    {
        Initiation
        , Shaping
        , Finish
        , OneTurn
        , TwoTurns
        , Custom
    }
    public class TimeCode
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public TimeCodeType TimeCodeType { get; set; }
        public string Name { get; set; }
        public int StartMs { get; set; }
        public int EndMs { get; set; }
        public int Index { get; set; }
    }
}
