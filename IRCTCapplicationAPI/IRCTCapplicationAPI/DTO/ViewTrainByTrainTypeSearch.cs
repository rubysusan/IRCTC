namespace IRCTCapplicationAPI.DTO
{
    public class ViewTrainByTrainTypeSearch
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string FromStatioinName { get; set; }
        public string ToStatioinName { get; set; }
        public DateTime Date { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReachingTime { get; set; }
    }
}
