using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Cars_Colect
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Car> Cars_Colect { get; set; }

        private CategoryMenuWindow _categoryMenuWindow; // Поле для зберігання посилання на CategoryMenuWindow

        public MainWindow(CategoryMenuWindow categoryMenuWindow) // Додайте параметр у конструктор
        {
            InitializeComponent();
            DataContext = this;
            Cars_Colect = new ObservableCollection<Car>();
            _categoryMenuWindow = categoryMenuWindow; // Зберігаємо посилання на існуючий екземпляр CategoryMenuWindow
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            // Отримуємо вибраний автомобіль
            Car selectedCar = (sender as Button).Tag as Car;

            // Створюємо вікно деталей автомобіля і передаємо вибраний автомобіль
            CarDetailsWindow detailsWindow = new CarDetailsWindow(selectedCar);

            // Показуємо вікно деталей
            detailsWindow.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // Отримуємо вибраний автомобіль
            Car selectedCar = (sender as Button).Tag as Car;

            // Створюємо вікно редагування даних автомобіля і передаємо вибраний автомобіль
            EditCarWindow editCarWindow = new EditCarWindow(selectedCar);

            // Показуємо вікно редагування
            editCarWindow.ShowDialog();

            // Оновлюємо інтерфейс після закриття вікна редагування, якщо внесені зміни
            if (editCarWindow.DialogResult == true)
            {
                // Оновлюємо відповідний автомобіль у колекції
                int index = Cars_Colect.IndexOf(selectedCar);
                if (index != -1)
                {
                    Cars_Colect[index] = editCarWindow.ModifiedCar;
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Створюємо та відкриваємо нове вікно для додавання автомобіля
            AddCarWindow addCarWindow = new AddCarWindow();
            if (addCarWindow.ShowDialog() == true)
            {
                // Якщо вікно було закрито з результатом "true", тобто дані були успішно додані
                // Тут можна отримати дані з вікна та додати новий автомобіль до колекції
                Cars_Colect.Add(new Car
                {
                    Brand = addCarWindow.txtBrand.Text,
                    Model = addCarWindow.txtModel.Text,
                    Year = addCarWindow.txtYear.Text,
                    Color = addCarWindow.txtColor.Text,
                    FuelType = addCarWindow.cmbFuelType.Text,
                    EngineVolume = addCarWindow.txtEngineVolume.Text,
                    VinCode = addCarWindow.txtVinCode.Text,
                    LicensePlate = addCarWindow.txtLicensePlate.Text,
                    Image = addCarWindow.CarImage
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ReturnToCategories_Click(object sender, RoutedEventArgs e)
        {
            _categoryMenuWindow.Show(); // Використовуємо існуючий екземпляр CategoryMenuWindow замість створення нового
            this.Hide();
        }
    }

    // Клас для представлення автомобіля
    public class Car : INotifyPropertyChanged
    {
        private string _brand;
        private string _model;
        private string _year;
        private string _color;
        private string _fuelType;
        private string _engineVolume;
        private string _vinCode;
        private string _licensePlate;

        private BitmapImage _image;

        public string Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                OnPropertyChanged("Brand");
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }

        public string Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

        public string FuelType
        {
            get { return _fuelType; }
            set
            {
                _fuelType = value;
                OnPropertyChanged("FuelType");
            }
        }

        public string EngineVolume
        {
            get { return _engineVolume; }
            set
            {
                _engineVolume = value;
                OnPropertyChanged("EngineVolume");
            }
        }

        public string VinCode
        {
            get { return _vinCode; }
            set
            {
                _vinCode = value;
                OnPropertyChanged("VinCode");
            }
        }
        public string LicensePlate
        {
            get { return _licensePlate; }
            set
            {
                _licensePlate = value;
                OnPropertyChanged("LicensePlate");
            }
        }
        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
