using EFCoreRelationships.Models;

namespace EFCoreRelationships.DTOs
{
    public class CharacterDTO
    {
        public string Name { get; set; } = string.Empty;
        public string RGPClass { get; set; } = string.Empty ;
        public string WeaponName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public static CharacterDTO ToCharacterDTO(Character character)
        => new CharacterDTO()
        {
            Name = character.Name,
            RGPClass = character.RPGClass,
            WeaponName = character.Weapon == null ? "none" : character.Weapon.Name,
            UserName = character.User.UserName
        };
    }
}
