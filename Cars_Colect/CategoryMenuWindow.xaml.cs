using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Cars_Colect
{
    public partial class CategoryMenuWindow : Window
    {
        public ObservableCollection<Category> Categories { get; set; }

        public CategoryMenuWindow()
        {
            InitializeComponent();
            DataContext = this;
            Categories = new ObservableCollection<Category>();
        }

        private void CreateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Відображення вікна для додавання категорії
            AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
            if (addCategoryWindow.ShowDialog() == true)
            {
                // Додавання категорії з обраним зображенням
                Categories.Add(new Category { Name = addCategoryWindow.CategoryName, Description = addCategoryWindow.CategoryDescription, Image = addCategoryWindow.CategoryImage });
            }
        }

        private void CategorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Відкриття нового вікна, якщо вибрана категорія
            if (((sender as ListBox).SelectedItem as Category) != null)
            {
                Category selectedCategory = (sender as ListBox).SelectedItem as Category;
                MainWindow mainWindow = new MainWindow(this);
                mainWindow.Show();
                this.Hide();
            }
        }
    }

    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BitmapImage Image { get; set; } // Властивість для зображення категорії
    }
}
