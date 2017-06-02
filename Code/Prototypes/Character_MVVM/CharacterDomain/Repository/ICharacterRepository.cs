using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharacterDomain.Model;

namespace CharacterDomain.Repository
{
    public interface ICharacterRepository
    {
        List<Character> GetAllCharacters();
        void SaveCharacter(Character character);
        void DeleteCharacter(Character character);

        FullCharacter GetCharacter(Character character);
        FullCharacter GetCharacter(string characterId);
    }
}
