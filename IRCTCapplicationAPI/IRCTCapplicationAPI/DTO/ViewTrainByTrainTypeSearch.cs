namespace IRCTCapplicationAPI.DTO
{
    public class ViewTrainByTrainTypeSearch
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string FromStationName { get; set; }
        public string ToStationName { get; set; }
        public int FromStationId { get; set; }
        public int ToStationId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReachingTime { get; set; }
    }
}
