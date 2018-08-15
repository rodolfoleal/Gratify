namespace Gratify.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public double Price { get; set; }

        public virtual WishList WishList { get; set; }
    }
}