namespace IRCTCapplicationAPI.DTO
{
    public class ViewTrainBySearch
    {
        public int TrainId { get; set; }
        public string TrainName { get; set;}
        public string FromStationName { get; set; }
        public string ToStationName { get;set; }
        public DateTime Date { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReachingTime { get; set; }
    }
}
