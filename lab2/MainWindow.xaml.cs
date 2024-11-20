using System.Windows;
using System.Windows.Controls;
using DrawClasses;
using lab2.DrawClasses;
using Models;
using OxyPlot;


namespace lab2;

public partial class MainWindow : Window
{
    private FractalManager fractalManager;
    private int iterations = 5; // default value
    private int disks = 2; // default value
    private Tower tower;
    private PlotModel complexityPlotModel;
    private ComplexityGraphDrawer complexityPlot;

    public MainWindow()
    {
        InitializeComponent();
        fractalManager = new FractalManager();
        PlotModel plotModel = new PlotModel();
        PlotModel complexityPlotModel = new PlotModel();
        ComplexityPlotView.Model = complexityPlotModel;
        complexityPlot = new ComplexityGraphDrawer(complexityPlotModel);
        tower = new Tower(plotModel);
        Plot.Model = plotModel;
    }

    private void OnFractalSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;
        var selectedItem = comboBox?.SelectedItem as ComboBoxItem;

        if (selectedItem != null)
        {
            fractalManager.DrawFractal(selectedItem, Plot, iterations, disks);

            string selectedContent = selectedItem.Content.ToString();
            if (selectedContent == "Hanoi Tower")
            {
                ComplexityPlotView.Visibility = Visibility.Visible;
                complexityPlot.DrawComplexityGraph(disks);
                Grid.SetRowSpan(ComplexityPlotView, 1);
            }
            else
            {
                ComplexityPlotView.Visibility = Visibility.Collapsed;
                Grid.SetRowSpan(Plot, 2);
            }
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
    
    private void OnStepForwardClick(object sender, RoutedEventArgs e)
    {
        tower.StepForward(); // Перемещение на шаг вперед
    }

    private void OnStepBackwardClick(object sender, RoutedEventArgs e)
    {
        tower.StepBackward(); // Перемещение на шаг назад
    }
}