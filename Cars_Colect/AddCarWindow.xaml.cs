using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Cars_Colect
{
    public partial class AddCarWindow : Window
    {
        public BitmapImage CarImage { get; set; }

        public AddCarWindow()
        {
            InitializeComponent();
            SetPlaceholderText();
        }

        private void SetPlaceholderText()
        {
            // Встановлюємо текст-зразок та значення Tag для текстових полів
            SetPlaceholder(txtBrand, "Марка");
            SetPlaceholder(txtModel, "Модель");
            SetPlaceholder(txtYear, "Рік випуску");
            SetPlaceholder(txtColor, "Колір");
            SetPlaceholder(txtEngineVolume, "Об'єм двигуна (л)");
            SetPlaceholder(txtVinCode, "Він код");
            SetPlaceholder(txtLicensePlate, "Реєстраційний номер");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.Tag = placeholder; // Значення для відновлення
            textBox.Foreground = Brushes.Gray; // Сірий колір тексту для текст-зразку
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Equals(textBox.Tag))
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black; // Чорний колір тексту при наборі
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Відновлюємо текст-зразок та сірий колір тексту
                textBox.Text = (string)textBox.Tag;
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            // Викликаємо діалогове вікно вибору зображення
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;

                // Завантажуємо вибране зображення
                CarImage = new BitmapImage(new Uri(imagePath));

                // Встановлюємо завантажене зображення як джерело для imgSample
                imgSample.Source = CarImage;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Операції для додавання нового автомобіля до основного вікна
            string brand = txtBrand.Text;
            string model = txtModel.Text;

            // Додайте код для збереження даних про новий автомобіль та його зображення
            // Наприклад, можна передати дані назад до головного вікна через властивість CarImage та закрити це вікно
            DialogResult = true;
        }
    }
}
