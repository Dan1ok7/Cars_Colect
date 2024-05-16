using System.Windows;
using System.Windows.Media.Imaging; // Доданий простір імен

namespace Cars_Colect
{
    public partial class CarDetailsWindow : Window
    {
        public CarDetailsWindow(Car car)
        {
            InitializeComponent();

            // Створюємо об'єкт CarDetails на основі вибраного автомобіля
            CarDetails carDetails = new CarDetails(car);

            // Встановлюємо об'єкт CarDetails як контекст даних для вікна
            DataContext = carDetails;

            // Передаємо зображення в об'єкт CarDetails
            carDetails.Image = car.Image;
        }
    }

    public class CarDetails
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; } // залишаємо як string
        public string Color { get; set; }
        public string FuelType { get; set; }
        public double EngineVolume { get; set; }
        public string VinCode { get; set; }
        public string LicensePlate { get; set; } // Додано властивість для реєстраційного номеру
        public BitmapImage Image { get; set; } // Властивість для зображення

        public CarDetails(Car car)
        {
            // Перевірка на null
            if (car != null)
            {
                Brand = car.Brand;
                Model = car.Model;
                Year = car.Year; // Не потрібно перетворювати
                Color = car.Color;
                FuelType = car.FuelType;
                // Якщо ви хочете перетворити об'єм двигуна на double, то залиште так як було
                EngineVolume = double.Parse(car.EngineVolume);
                VinCode = car.VinCode;
                LicensePlate = car.LicensePlate; // Додано передачу реєстраційного номеру
            }
        }
    }
}
