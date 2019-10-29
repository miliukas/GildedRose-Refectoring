namespace csharp
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }

        public  bool Equals(Item obj)
        {
            if (this.Name.Equals(obj.Name) && this.Quality == obj.Quality && this.SellIn == this.SellIn)
                return true;
            return false;
        }
    }
}
