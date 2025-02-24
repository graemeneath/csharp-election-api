namespace election_api.Model
{
    public class PartyResult
    {
        public required string party { get; set; }
        public int votes { get; set; }
        public decimal share { get; set; }
    }
}