namespace MagicVilla.Models {

    public class Match
    {
        public int Id { get; set; }
        public Profile Profile1 { get; set; }
        public Profile Profile2 { get; set; }
        public DateTime MatchDate { get; set; }
    }

}