using System.Windows;
using System.Windows.Controls;
using DrawClasses;


namespace lab2;

public partial class MainWindow : Window
{
    private FractalManager fractalManager;
    private int iterations = 5; // default value
    private int disks = 2; // default value

    public MainWindow()
    {
        InitializeComponent();
        fractalManager = new FractalManager();
    }

    private void OnFractalSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;
        var selectedItem = comboBox?.SelectedItem as ComboBoxItem;

        if (selectedItem != null)
        {
            fractalManager.DrawFractal(selectedItem, Plot, iterations, disks);
        }
    }

    void Iterations_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (int.TryParse(Iterations.Text, out int result))
        {
            iterations = result;
        }
        else
        {
            iterations = 5;
        }
    }
    void Disks_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (int.TryParse(Disks.Text, out int result))
        {
            disks = result;
        }
        else
        {
            disks = 2;
        }
    }
}