using System.Windows;
using System.Windows.Controls;
using DrawClasses;


namespace lab2;

public partial class MainWindow : Window
{
    private FractalManager fractalManager;

    public MainWindow()
    {
        InitializeComponent();
        fractalManager = new FractalManager(); // Инициализация FractalManager
    }
        
    private void OnFractalSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;
        var selectedItem = comboBox.SelectedItem as ComboBoxItem;

        if (selectedItem != null)
        {
            fractalManager.DrawFractal(selectedItem, Plot); // Передаем выбранный элемент и Plot
        }
    }
}