using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characterParty;
        private List<Item> itemPool;

        public WarController()
        {
            this.characterParty = new List<Character>();
            this.itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            var characterType = args[0];
            var name = args[1];

            Character character;
            if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            this.characterParty.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];
            Item item;
            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            this.itemPool.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            var character = this.characterParty.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            var item = this.itemPool.Last();
            character.Bag.AddItem(item);
            this.itemPool.Remove(item);

            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = this.characterParty.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            //var item = this.itemPool.FirstOrDefault(x => x.GetType().Name == itemName);
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            foreach (var character in this.characterParty.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                var status = character.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            Warrior attacker = (Warrior)this.characterParty.FirstOrDefault(x => x.Name == attackerName);
            Character reciever = this.characterParty.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            else if (reciever == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attacker.Attack(reciever);

            var result = new StringBuilder();

            result.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {reciever.Health}/{reciever.BaseHealth} HP and {reciever.Armor}/{reciever.BaseArmor} AP left!");
            if (!reciever.IsAlive)
            {
                result.AppendLine($"{reciever.Name} is dead!");
            }

            return result.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            Priest healer = (Priest)this.characterParty.FirstOrDefault(x => x.Name == healerName);
            Character healingReciever = this.characterParty.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            else if (healingReciever == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            healer.Heal(healingReciever);
            //healingReciever.Health += healer.AbilityPoints;

            return $"{healer.Name} heals {healingReceiverName} for {healer.AbilityPoints}! {healingReceiverName} has {healingReciever.Health} health now!";
        }
    }
}
