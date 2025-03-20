namespace ManchesterCityJerseys.Core.Models
{
    public class Jersey
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
