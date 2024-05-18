using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Cars_Colect
{
    public partial class AddCategoryWindow : Window
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public BitmapImage CategoryImage { get; set; } // Оновлено назву властивості

        public AddCategoryWindow()
        {
            InitializeComponent();
            // Встановлюємо зображення за замовчуванням
            CategoryImage = new BitmapImage(new Uri(@"C:\Users\Dania\Desktop\ДИПЛОМ\Проект\Cars_Colect\Cars_Colect\Image\default.png", UriKind.Absolute)); // Встановлюємо абсолютний шлях
            imgSample.Source = CategoryImage;
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Логіка для додавання категорії
            CategoryName = txtCategoryName.Text;
            CategoryDescription = txtCategoryDescription.Text;

            DialogResult = true; // Встановлюємо результат діалогу як true
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                // Завантаження обраного файлу зображення
                CategoryImage = new BitmapImage(new Uri(openFileDialog.FileName));
                imgSample.Source = CategoryImage;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == textBox.Tag as string)
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag as string;
            }
        }
    }
}
