namespace EFCoreRelationships.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RPGClass { get; set; } = string.Empty;
        public User User { get; set; }
        public Weapon Weapon { get; set; }
        
    }
}
