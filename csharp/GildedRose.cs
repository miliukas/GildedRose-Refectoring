﻿using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        public void UpdateQuality2()
        {
            for (int i = 0; i < Items.Count; i++)
            {

                string caseSwitch = GetItemCategorie(Items[i].Name);
                int degrade;
                switch (caseSwitch)
                {
                    case "Sulfuras":
                        Items[i].SellIn -= 1;
                        break;
                    case "Backstage passes":
                        break;
                    case "Aged Brie":
                        break;
                    case "Conjured":
                        degrade = valueOfQualityDegradeForCasualItems(Items[i].SellIn);
                        if (Items[i].Quality - degrade*2 < 0)
                        {
                            Items[i].Quality = 0;
                            Items[i].SellIn--;
                        }
                        else
                        {
                            Items[i].Quality -= degrade*2;
                            Items[i].SellIn--;
                        }
                        break;
                    default:
                        degrade = valueOfQualityDegradeForCasualItems(Items[i].SellIn);
                        if (Items[i].Quality - degrade < 0)
                        {
                            Items[i].Quality = 0;
                            Items[i].SellIn--;
                        }
                        else
                        {
                            Items[i].Quality -= degrade;
                            Items[i].SellIn--;
                        }
                        break;
                }

            }
        }

        private string GetItemCategorie(string name)
        {
            if (name.Contains("Sulfuras"))
                return "Sulfuras";
            else if (name.Contains("Aged Brie"))
                return "Aged Brie";
            else if (name.Contains("Backstage passes"))
                return "Backstage passes";
            else if (name.Contains("Conjured"))
                return "Conjured";
            else
                return "Default";
        }

        private int valueOfQualityDegradeForCasualItems(int sellin)
        {
            if (sellin > 0)
                return 1;
            else 
                return 2;
        }

    }
}
