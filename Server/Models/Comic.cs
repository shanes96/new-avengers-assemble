namespace Server.Models
{
    public class Comic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Extension { get; set; }
        public decimal Price { get; set; } = 10.00M; 

    }
}
