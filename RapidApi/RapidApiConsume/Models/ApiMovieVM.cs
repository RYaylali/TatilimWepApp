namespace RapidApiConsume.Models
{
    public class ApiMovieVM
    {
        public int rank { get; set; }//isimler redapidekilerin birebir aynısı olmalı
        public string title { get; set; }
        public string rating { get; set; }
        public string trailer { get; set; }
    }
}
