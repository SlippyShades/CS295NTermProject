using System;
using System.Linq;
using MTG295NTermProject.Models;

namespace MTG295NTermProject.Data
{
    public class SeedData
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Cards.Any())
            {
                CardModel card = new CardModel
                {
                    CardName = "Forest Guardian",
                    ManaCost = 4,
                    CardType = AllowedTypes.CardType.Creature,
                    CardColor = AllowedColors.CardColor.Green,
                    CreatureType = "Elf",
                    CreatureType2 = "Druid",
                    Power = "3",
                    Toughness = "5",
                    OracleText = "Tap: Add {G}{G}.",
                    Quantity = 2
                };
                context.Cards.Add(card);

                card = new CardModel
                {
                    CardName = "Mystic Insight",
                    ManaCost = 3,
                    CardType = AllowedTypes.CardType.Sorcery,
                    CardColor = AllowedColors.CardColor.Blue,
                    OracleText = "Draw two cards.",
                    Quantity = 4
                };
                context.Cards.Add(card);

                card = new CardModel
                {
                    CardName = "Celestial Phoenix",
                    ManaCost = 4,
                    CardType = AllowedTypes.CardType.Creature,
                    CardColor = AllowedColors.CardColor.Red,
                    CardColor2 = "White",
                    CreatureType = "Phoenix",
                    Power = "3",
                    Toughness = "3",
                    OracleText = "Flying, Haste. When Celestial Phoenix dies, return it to your hand.",
                    Quantity = 2
                };
                context.Cards.Add(card);

                card = new CardModel
                {
                    CardName = "Soulbond Twins",
                    ManaCost = 3,
                    CardType = AllowedTypes.CardType.Creature,
                    CardColor = AllowedColors.CardColor.Blue,
                    CardColor2 = "Black",
                    CreatureType = "Spirit",
                    CreatureType2 = "Wizard",
                    Power = "2",
                    Toughness = "2",
                    OracleText = "Soulbond (You may pair this creature with another unpaired creature when either enters the battlefield.) As long as paired, each of those creatures gets +1/+1.",
                    Quantity = 2
                };
                context.Cards.Add(card);

                context.SaveChanges();
            }
        }
    }
}