using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using CharacterDomain.Model;
using System.Xml.Linq;

namespace CharacterDomain.Repository
{
    public class XmlCharacterRepository : ICharacterRepository
    {
        public List<Character> GetAllCharacters()
        {
            return new List<Character> 
            { 
                new Character() {  FamiliarName = "Johnny", Description = "Johnny is the main protagonist.", Aliases = "Johnno, Happy Kid" },
                new Character() { FamiliarName = "Sally", Description = "Sally is the mistress in distress.", Aliases = "Blondy, Sexy" },
                new Character() { FamiliarName = "Billy Boy", Description = "The village bully that must be bested.", Aliases = ""},
                new Character() { FamiliarName = "Mr. Claasens", Description = "Teacher of the drunken martial arts.", Aliases = "Toad" },
            };
        }

        public void SaveCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        public void DeleteCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        
        public FullCharacter GetCharacter(string characterId)
        {
            throw new NotImplementedException();
        }


        public FullCharacter GetCharacter(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
