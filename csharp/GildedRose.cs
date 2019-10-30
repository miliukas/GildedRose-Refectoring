using System.Collections.Generic;

public enum ItemCategorie
{
    Default, Sulfuras, AgedBrie, BackstagePasses, Conjured
}

namespace csharp
{
    public class GildedRose
    {
        const int maxQuality = 50;
        const int minQuality = 0;
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                ItemCategorie caseSwitch = GetItemCategory(Items[i].Name);
                int degrade;
                int increase;
                switch (caseSwitch)
                {
                    case ItemCategorie.Sulfuras:
                        break;
                    case ItemCategorie.BackstagePasses:
                        if (Items[i].SellIn - 1 < minQuality) {
                            Items[i].Quality = 0;
                            break;
                        }
                        increase = valueOfQualityIncreaseForSpecialItems(Items[i].SellIn);
                        if (Items[i].Quality + increase < maxQuality)
                        {
                            Items[i].Quality += increase;
                        }
                        else { Items[i].Quality = 50; Items[i].SellIn--;}
                        break;
                    case ItemCategorie.AgedBrie:
                        if (Items[i].Quality < maxQuality)
                            Items[i].Quality++;
                        break;
                    case ItemCategorie.Conjured:
                        degrade = valueOfQualityDegradeForCasualItems(Items[i].SellIn);
                        if (Items[i].Quality - degrade*2 < minQuality)
                        {
                            Items[i].Quality = 0;
                        }
                        else
                        {
                            Items[i].Quality -= degrade*2;
                        }
                        break;
                    default:
                        degrade = valueOfQualityDegradeForCasualItems(Items[i].SellIn);
                        if (Items[i].Quality - degrade < maxQuality)
                        {
                            Items[i].Quality = 0;
                        }
                        else
                        {
                            Items[i].Quality -= degrade;
                        }
                        break;
                }
                Items[i].SellIn--;
            }
        }

        private ItemCategorie GetItemCategory(string name)
        {
            if (name.Contains("Sulfuras"))
                return ItemCategorie.Sulfuras;
            else if (name.Contains("Aged Brie"))
                return ItemCategorie.AgedBrie;
            else if (name.Contains("Backstage passes"))
                return ItemCategorie.BackstagePasses;
            else if (name.Contains("Conjured"))
                return ItemCategorie.Conjured;
            else
                return ItemCategorie.Default;
        }

        // To count degrade value by sellin
        private int valueOfQualityDegradeForCasualItems(int sellin)
        {
            if (sellin > 0)
                return 1;
            else 
                return 2;
        }

        private int valueOfQualityIncreaseForSpecialItems(int sellin)
        {
            if (sellin > 5 && sellin < 11)
                return 2;
            else if (sellin < 6 && sellin > 0)
                return 3;
            else
                return 1;
        }
    }
}
