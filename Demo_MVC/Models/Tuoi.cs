namespace Demo_MVC.Models
{
    public class Tuoi
    {
        public string FullName { get; set; } = string.Empty;
        public int YearOfBirth { get; set; } 
        public int Age 
        {
            get
            {
                return DateTime.Now.Year - YearOfBirth;
            }
        }

    }
}