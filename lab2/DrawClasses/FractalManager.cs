using OxyPlot.Wpf;
using System.Windows.Controls;
using AbstractClasses;
using Fractals;
using Models;
using OxyPlot;
using System.Runtime.CompilerServices;
namespace DrawClasses;

public class FractalManager
{
    public void DrawFractal(ComboBoxItem selectedItem, PlotView plot, int iterations, int disks)
    {
        PlotModel plotModel = new PlotModel();
        
        switch (selectedItem.Content.ToString())
        {
            case "Julia Fractal":
                DrawJuliaFractal(plotModel, iterations);
                break;
            case "Pythagoras Tree":
                DrawPythagorasTreeFractal(plotModel, iterations);
                break;
            case "Snowflake Curve":
                DrawSnowflakeCurve(plotModel, iterations);
                break;
            case "Hanoi Tower":
                DrawHanoiTower(plotModel, iterations, disks);
                break;
        }

        plot.Model = plotModel;
        plot.InvalidatePlot();
    }

    private void DrawJuliaFractal(PlotModel plotModel, int iterations)
    {
        var juliaFractal = new Julia(-0.9659, 0.27015, -1.5, 1.5, -1.5, 1.5, iterations);
        juliaFractal.Draw(plotModel);
    }

    private void DrawPythagorasTreeFractal(PlotModel plotModel, int iterations)
    {
        var pythagorasTree = new PythagorasTreeFractal(0, 0, 100, -Math.PI / 2, iterations);
        pythagorasTree.Draw(plotModel);
    }

    private void DrawSnowflakeCurve(PlotModel plotModel, int iterations)
    {
        var snowflakeCurve = new SnowflakeCurve(3, 5, 10, 15, iterations);
        snowflakeCurve.Draw(plotModel);
    }

    private void DrawHanoiTower(PlotModel plotModel, int iterations, int disks)
    {
        var hanoiTowersRenderer = new Tower(plotModel);
        hanoiTowersRenderer.AnimateTowerOfHanoi(disks, iterations);
    }
}
