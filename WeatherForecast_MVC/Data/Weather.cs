namespace WeatherForecast_MVC.Data
{
    public class Weather
    {
        public string? Place { get; set; }
        public int? Temprature { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
