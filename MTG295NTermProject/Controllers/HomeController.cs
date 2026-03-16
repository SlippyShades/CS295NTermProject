using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTG295NTermProject.Data;
using MTG295NTermProject.Models;

namespace MTG295NTermProject.Controllers
{
    public class HomeController : Controller
    {

        AppDbContext context;

        public HomeController(AppDbContext c)
        {
            context = c;
        }




        [HttpGet]
        public IActionResult AddToWanted()
        {
            
            var model = context.Cards.Select(c => new SelectListItem
            {
                Text = c.CardName
            }).ToList();

            ViewBag.Cards = model;
            return View();
        }
        [HttpPost]
        public IActionResult AddToWanted(WantedCardModel wantedCard)
        {
            if (ModelState.IsValid)
            {
                var newWanted = new WantedCardModel
                {
                    CardName = wantedCard.CardName
                };

                
                context.WantedCards.Add(newWanted);
                context.SaveChanges();

                return RedirectToAction("WantedCards");
            }

            
            return View(wantedCard);
        }

        public IActionResult WantedCards()
        {
            var list = context.WantedCards
                .ToList();
            return View(list);
        }






        [HttpPost]
        public IActionResult AddCard(CardModel card)
        {
            if (ModelState.IsValid)
            {
                context.Cards.Add(card);
                context.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(card);
        }

        



        public IActionResult Index()
        {
            var cards = context.Cards;
            var cardsList = cards.ToList();
            return View(cardsList);
        }
        [HttpGet]
        public IActionResult AddCard()
        {
            return View();
        }


        public IActionResult Filter(
    string cardname, int? manacost,
    string cardtype, string cardtypetwo, string cardtypethree,
    string cardcolor, string cardcolor2, string cardcolor3, string cardcolor4, string cardcolor5,
    string legendary, string kindred, string excludeColor, string excludeColor2, string excludeColor3, string excludeColor4, string excludeColor5,
    string creatureType, string creatureType2, string creatureType3, string creatureType4,
    string tough, string power, int? quantity)
        {
            var cards = context.Cards.AsQueryable();

            // Card Name
            if (!string.IsNullOrEmpty(cardname))
                cards = cards.Where(c => c.CardName.Contains(cardname));

            // Mana Cost
            if (manacost.HasValue)
                cards = cards.Where(c => c.ManaCost == manacost);

            // Card Types
            if (!string.IsNullOrEmpty(cardtype) || !string.IsNullOrEmpty(cardtypetwo) || !string.IsNullOrEmpty(cardtypethree))
            {
                cards = cards.Where(c =>
                    (!string.IsNullOrEmpty(cardtype) &&
                        (c.CardType.ToString().Contains(cardtype) || c.CardType2.Contains(cardtype) || c.CardType3.Contains(cardtype)))
                    ||
                    (!string.IsNullOrEmpty(cardtypetwo) &&
                        (c.CardType.ToString().Contains(cardtypetwo) || c.CardType2.Contains(cardtypetwo) || c.CardType3.Contains(cardtypetwo)))
                    ||
                    (!string.IsNullOrEmpty(cardtypethree) &&
                        (c.CardType.ToString().Contains(cardtypethree) || c.CardType2.Contains(cardtypethree) || c.CardType3.Contains(cardtypethree)))
                );
            }

            // Include Colors
            var includeColors = new[] { cardcolor, cardcolor2, cardcolor3, cardcolor4, cardcolor5 }
                .Where(c => !string.IsNullOrEmpty(c))
                .ToArray();

            if (includeColors.Any())
            {
                cards = cards.Where(c => includeColors.Any(color =>
                    c.CardColor.ToString().Contains(color) ||
                    c.CardColor2.Contains(color) ||
                    c.CardColor3.Contains(color) ||
                    c.CardColor4.Contains(color) ||
                    c.CardColor5.Contains(color)
                ));
            }

            // Exclude Colors
            var excludeColors = new[] { excludeColor, excludeColor2, excludeColor3, excludeColor4, excludeColor5 }
                .Where(c => !string.IsNullOrEmpty(c))
                .ToArray();

            if (excludeColors.Any())
            {
                cards = cards.Where(c => !excludeColors.Any(color =>
                    c.CardColor.ToString().Contains(color) ||
                    c.CardColor2.Contains(color) ||
                    c.CardColor3.Contains(color) ||
                    c.CardColor4.Contains(color) ||
                    c.CardColor5.Contains(color)
                ));
            }

            // Legendary & Kindred
            if (!string.IsNullOrEmpty(legendary))
                cards = cards.Where(c => c.Legendary.Contains(legendary));

            if (!string.IsNullOrEmpty(kindred))
                cards = cards.Where(c => c.Kindred.Contains(kindred));

            // Creature Types
            var creatureFilters = new[] { creatureType, creatureType2, creatureType3, creatureType4 }
                .Where(c => !string.IsNullOrEmpty(c))
                .ToArray();

            if (creatureFilters.Any())
            {
                cards = cards.Where(c => creatureFilters.Any(ct =>
                    c.CreatureType.Contains(ct) ||
                    c.CreatureType2.Contains(ct) ||
                    c.CreatureType3.Contains(ct) ||
                    c.CreatureType4.Contains(ct)
                ));
            }

            // Toughness & Power
            if (!string.IsNullOrEmpty(tough))
                cards = cards.Where(c => c.Toughness == tough);

            if (!string.IsNullOrEmpty(power))
                cards = cards.Where(c => c.Power == power);

            // Quantity
            if (quantity.HasValue)
                cards = cards.Where(c => c.Quantity == quantity);

            // Save filter values to ViewData for form persistence
            ViewData["CardnameFilter"] = cardname;
            ViewData["ManacostFilter"] = manacost;
            ViewData["CardtypeFilter"] = cardtype;
            ViewData["CardtypeTwoFilter"] = cardtypetwo;
            ViewData["CardtypeThreeFilter"] = cardtypethree;
            ViewData["CardcolorFilter"] = cardcolor;
            ViewData["Cardcolor2Filter"] = cardcolor2;
            ViewData["Cardcolor3Filter"] = cardcolor3;
            ViewData["Cardcolor4Filter"] = cardcolor4;
            ViewData["Cardcolor5Filter"] = cardcolor5;
            ViewData["excludecolorFilter"] = excludeColor;
            ViewData["excludecolor2Filter"] = excludeColor2;
            ViewData["excludecolor3Filter"] = excludeColor3;
            ViewData["excludecolor4Filter"] = excludeColor4;
            ViewData["excludecolor5Filter"] = excludeColor5;
            ViewData["LegendaryFilter"] = legendary;
            ViewData["KindredFilter"] = kindred;
            ViewData["CreatureTypeFilter"] = creatureType;
            ViewData["CreatureTypeFilter2"] = creatureType2;
            ViewData["CreatureTypeFilter3"] = creatureType3;
            ViewData["CreatureTypeFilter4"] = creatureType4;
            ViewData["ToughFilter"] = tough;
            ViewData["PowerFilter"] = power;
            ViewData["QuantityFilter"] = quantity;

            return View("Index", cards.ToList());
        }


    }
}
