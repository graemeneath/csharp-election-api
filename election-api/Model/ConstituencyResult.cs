namespace election_api.Model
{
    public class ConstituencyResult
    {
        public int Id { get; set; }
        public required string name { get; set; }
        public int seqNo { get; set; }
        public List<PartyResult>? partyResults { get; set; }
    }
}
