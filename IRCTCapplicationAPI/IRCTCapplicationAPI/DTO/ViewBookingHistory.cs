namespace IRCTCapplicationAPI.DTO
{
    public class ViewBookingHistory
    {
        public int BookingId {  get; set; }
        public string Train { get; set;}
        public string Coach { get; set;}
        public string FromStation { get; set;}
        public string ToStation { get; set;}
        public int Count { get; set; }
        public double Total { get; set; }
    }
}
