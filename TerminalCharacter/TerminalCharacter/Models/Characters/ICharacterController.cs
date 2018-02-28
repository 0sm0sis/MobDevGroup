using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCharacter.Models
{
    public interface ICharacterController<T>
    {
        // Uses brute force attack
        // Equivalent of physical attack in most dungeon crawlers
        int BruteForceAttack(ICharacter character);

        // applies damage to the given character
        // returns 0 if still alive, -1 if the character died
        // if it is a monster, returns the experience instead
        int TakeDamage(ICharacter character, int damage, int damType);

        // uses program
        // equivalent of magic in most dungeon crawlers
        int UseProgram(ICharacter character);

        // Drops all Items on Character
        // Must pass in character 
        List<Item> DropItem();
    }
}
