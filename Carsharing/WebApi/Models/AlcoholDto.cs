namespace WebApi.Models
{
    public class AlcoholDto
    {
        public double Percent { get; set; }
        public double Quantity { get; set; }
        public double Weight { get; set; }
        public string? Gender { get; set; }
        public int? MinutesAfter { get; set; }
    }
}
