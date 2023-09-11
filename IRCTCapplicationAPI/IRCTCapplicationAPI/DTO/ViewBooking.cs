namespace IRCTCapplicationAPI.DTO
{
    public class ViewBooking
    {
        public int BookingId { get; set; }
        public int TrainClassId { get; set; }
        public int FromStop { get; set; }
        public int ToStop { get; set; }
        public int Count { get; set; }
        public double TotalCost { get; set; }
        public int UserId { get; set; }
    }
}
