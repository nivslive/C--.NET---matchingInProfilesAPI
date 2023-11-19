namespace MagicVilla.Models {
    public class Profile {
        public int Id {get;set;}
        public int Age {get;set;}
        public required string Name {get;set;}
        public required string Sex {get;set;}
        public string? Bio {get;set;}

    }
}