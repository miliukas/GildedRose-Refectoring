using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void updateQuality()
        {
            //Arrange
            IList<Item> resultItems = createItemsForTesting();
            IList<Item> expectedItems = createExpectedItemsForTesting();

            //Act 
            GildedRose app = new GildedRose(resultItems);
            for (int i = 0; i < 30; i++)
            {
                app.UpdateQuality();
            }

            //Assert
            for (int i = 0; i < resultItems.Count; i++)
            {
                Assert.True(resultItems[i].Equals(expectedItems[i]));
            }
        }

        private IList<Item> createItemsForTesting()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            return Items;
        }

        private IList<Item> createExpectedItemsForTesting()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = -20, Quality = 0},
                new Item {Name = "Aged Brie", SellIn = -28, Quality = 30},
                new Item {Name = "Elixir of the Mongoose", SellIn = -25, Quality = 0},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -30, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -31, Quality = 80},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -15, Quality = 0},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -20,  Quality = 0},
                new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -25,Quality = 0},
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = -27, Quality = 0}
            };
            return Items;
        }
    }
}

