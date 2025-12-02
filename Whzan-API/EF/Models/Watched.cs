namespace Whzan_API.EF.Models
{
    public class Watched
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
