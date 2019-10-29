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
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Conjured", Items[0].Name);
            
        }
    }
}
