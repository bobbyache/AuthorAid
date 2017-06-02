using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharacterDomain.Repository;
using CharacterDomain.Model;

namespace CharacterTests.TestDomain
{
    public class TestCharacterRepository : ICharacterRepository
    {
        private List<Character> characterFile;

        public TestCharacterRepository()
        {
            characterFile = new List<Character> 
            { 
                new Character() { FamiliarName = "Johnny", Description = "Johnny is the main protagonist." },
                new Character() { FamiliarName = "Sally", Description = "Sally is the mistress in distress." },
                new Character() { FamiliarName = "Billy Boy", Description = "The village bully that must be bested." },
                new Character() { FamiliarName = "Mr. Claasens", Description = "Teacher of the drunken martial arts." },
            };
        }
        
        public List<Character> GetAllCharacters()
        {
            return characterFile;
        }

        public void SaveCharacter(Character character)
        {
            var count = characterFile.Where(c => c.Id == character.Id).Count();

            if (count == 0)
                characterFile.Add(character);
        }

        public void DeleteCharacter(Character character)
        {
            if (characterFile.Contains(character))
                characterFile.Remove(character);
        }

        public FullCharacter GetCharacter(string characterId)
        {
            return (characterFile.Where(c => c.Id == characterId).SingleOrDefault()) as FullCharacter;
        }

        public FullCharacter GetCharacter(Character character)
        {
            return (characterFile.Where(c => c.Id == character.Id).SingleOrDefault()) as FullCharacter;
        }
    }
}
