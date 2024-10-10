using OxyPlot.Wpf;
using System.Windows.Controls;
using AbstractClasses;
using Fractals;
using Models;
using OxyPlot;
namespace DrawClasses;

public class FractalManager
{
    public void DrawFractal(ComboBoxItem selectedItem, PlotView plot)
    {
        PlotModel plotModel = new PlotModel();

        switch (selectedItem.Content.ToString())
        {
            case "Julia Fractal":
                DrawJuliaFractal(plotModel);
                break;
            case "Pythagoras Tree":
                DrawPythagorasTreeFractal(plotModel);
                break;
            case "Snowflake Curve":
                DrawSnowflakeCurve(plotModel);
                break;
            case "Hanoi Tower":
                DrawHanoiTower(plotModel);
                break;
        }

        plot.Model = plotModel;
        plot.InvalidatePlot();
    }

    private void DrawJuliaFractal(PlotModel plotModel)
    {
        var juliaFractal = new Julia(-0.9659, 0.27015, -1.5, 1.5, -1.5, 1.5, 100);
        juliaFractal.Draw(plotModel);
    }

    private void DrawPythagorasTreeFractal(PlotModel plotModel)
    {
        var pythagorasTree = new PythagorasTreeFractal(0, 0, 100, -Math.PI / 2, 15);
        pythagorasTree.Draw(plotModel);
    }

    private void DrawSnowflakeCurve(PlotModel plotModel)
    {
        var snowflakeCurve = new SnowflakeCurve(0, 0, 10, 10, 5);
        snowflakeCurve.Draw(plotModel);
    }

    private void DrawHanoiTower(PlotModel plotModel)
    {
        var hanoiTowersRenderer = new Tower(plotModel);
        hanoiTowersRenderer.DrawTowers();
    }
}
