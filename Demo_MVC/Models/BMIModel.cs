namespace Demo_MVC.Models
{
    public class BMIModel
    {
        public double Height { get; set; }  // Chiều cao (m)
        public double Weight { get; set; }  // Cân nặng (kg)
        public double Result { get; set; }  // Kết quả BMI
        public string Category { get; set; } = string.Empty; // Phân loại BMI
    }
}
