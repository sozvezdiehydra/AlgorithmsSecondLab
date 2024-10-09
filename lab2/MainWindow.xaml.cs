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

        var pythagorasTree = new PythagorasTreeFractal(0, 0, 100, -Math.PI / 2, 10);
        var plotModel = new PlotModel();
        pythagorasTree.Draw(plotModel);
        DataContext = this;
        PythagorasTreePlotModel = plotModel;

        /*var snowflakeCurve = new SnowflakeCurve(0, 0, 10, 10, 5);
        var plotModel = new PlotModel();
        snowflakeCurve.Draw(plotModel);
        DataContext = this;
        SnowflakeCurvePlotModel = plotModel;*/

        /*var julia = new Julia(-0.7, 0.27015, -1.5, 1.5, -1.5, 1.5, 50);
        var plotModel = new PlotModel();
        julia.Draw(plotModel);
        DataContext = this;
        JuliaPlotModel = plotModel;*/
    }

    public PlotModel JuliaPlotModel { get; set; }
    public PlotModel SnowflakeCurvePlotModel { get; set; }
    public PlotModel PythagorasTreePlotModel { get; set; }
}