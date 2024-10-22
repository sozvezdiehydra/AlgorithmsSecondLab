using OxyPlot;
using OxyPlot.Axes;

namespace AbstractClasses;

public abstract class Algorithms
{
    public abstract void Draw(PlotModel plotModel);
    public void AddAxes(PlotModel plotModel)
    {
        var xAxis = new LinearAxis
        {
            Position = AxisPosition.Bottom,
            MajorGridlineStyle = LineStyle.None,
            MinorGridlineStyle = LineStyle.None,
            TickStyle = TickStyle.None,
            LabelFormatter = _ => string.Empty
        };

        var yAxis = new LinearAxis
        {
            Position = AxisPosition.Left,
            MajorGridlineStyle = LineStyle.None,
            MinorGridlineStyle = LineStyle.None,
            TickStyle = TickStyle.None,
            LabelFormatter = _ => string.Empty
        };

        plotModel.Axes.Add(xAxis);
        plotModel.Axes.Add(yAxis);
    }
}
