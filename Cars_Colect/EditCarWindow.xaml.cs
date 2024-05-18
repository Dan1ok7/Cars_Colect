using System.Windows;

namespace Cars_Colect
{
    public partial class EditCarWindow : Window
    {
        private Car _selectedCar;

        // Додайте властивість ModifiedCar
        public Car ModifiedCar
        {
            get { return _selectedCar; }
            set { _selectedCar = value; }
        }

        public EditCarWindow(Car selectedCar)
        {
            InitializeComponent();
            _selectedCar = selectedCar;

            // Встановлюємо контекст даних вікна редагування на вибраний автомобіль
            DataContext = _selectedCar;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Ось ви можете додати код для збереження змін у вибраному автомобілі
            // Після збереження змін закриваємо вікно
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Просто закриваємо вікно без збереження змін
            Close();
        }
    }
}
