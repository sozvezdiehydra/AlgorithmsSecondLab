using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using lab2.Fractals;
using OxyPlot;

namespace lab2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        var pythagorasTree = new PythagorasTreeFractal(200, 0, 200, -Math.PI / 2, 12);
        var plotModel = new PlotModel();
        pythagorasTree.Draw(plotModel);

        DataContext = this;
        PythagorasTreePlotModel = plotModel;
    }
    
    public PlotModel PythagorasTreePlotModel { get; set; }
}