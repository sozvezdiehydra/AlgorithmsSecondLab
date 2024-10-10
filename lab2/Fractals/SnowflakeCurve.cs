using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
namespace Fractals;
using AbstractClasses;

public class SnowflakeCurve : Algorithms
{
    private double x1, y1, x2, y2;
    private int iterations;

    public SnowflakeCurve(double x1, double y1, double x2, double y2, int iterations)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.iterations = iterations;
    }

    public override void Draw(PlotModel plotModel)
    {
        var linearAxis = new LinearAxis();
        var lineSeries = new LineSeries();
        
        // delete x axis
        var xAxis = new LinearAxis
        {
            Position = AxisPosition.Bottom,
            MajorGridlineStyle = LineStyle.None,
            MinorGridlineStyle = LineStyle.None,
            TickStyle = TickStyle.None,
            LabelFormatter = _ => string.Empty
        };
        // delete y axis
        var yAxis = new LinearAxis
        {
            Position = AxisPosition.Left,
            MajorGridlineStyle = LineStyle.None,
            MinorGridlineStyle = LineStyle.None,
            TickStyle = TickStyle.None,
            LabelFormatter = _ => string.Empty
        };
        
        DrawSnowflakeCurve(lineSeries, x1, y1, x2, y2, iterations);
        plotModel.Series.Add(lineSeries);
        plotModel.Axes.Add(xAxis);
        plotModel.Axes.Add(yAxis);
    }

    private void DrawSnowflakeCurve(LineSeries lineSeries, double x1, double y1, double x2, double y2, int iterations)
    {
        // recursion exit
        if (iterations == 0)
        {
            lineSeries.Points.Add(new DataPoint(x1, y1));
            lineSeries.Points.Add(new DataPoint(x2, y2));
            return;
        }

        double x3 = x1 + (x2 - x1) / 3;
        double y3 = y1 + (y2 - y1) / 3;

        double x4 = x1 + (x2 - x1) * 2 / 3;
        double y4 = y1 + (y2 - y1) * 2 / 3;

        double dx = x4 - x3;
        double dy = y4 - y3;

        double x5 = x3 - dy + (dx * Math.Cos(Math.PI / 4) + dy * Math.Sin(Math.PI / 4));
        double y5 = y3 + dx + (dx * Math.Sin(Math.PI / 4) + dy * Math.Cos(Math.PI / 4));

        double x6 = x3 + dy + (dx * Math.Cos(Math.PI / 4) - dy * Math.Sin(Math.PI / 4));
        double y6 = y3 - dx + (dx * Math.Sin(Math.PI / 4) - dy * Math.Cos(Math.PI / 4));

        DrawSnowflakeCurve(lineSeries, x1, y1, x3, y3, iterations - 1);
        lineSeries.Points.Add(new DataPoint(double.NaN, double.NaN)); // Добавляем разрыв между линиями
        DrawSnowflakeCurve(lineSeries, x3, y3, x5, y5, iterations - 1);
        lineSeries.Points.Add(new DataPoint(double.NaN, double.NaN)); // Добавляем разрыв между линиями
        DrawSnowflakeCurve(lineSeries, x5, y5, x4, y4, iterations - 1);
        lineSeries.Points.Add(new DataPoint(double.NaN, double.NaN)); // Добавляем разрыв между линиями
        DrawSnowflakeCurve(lineSeries, x4, y4, x2, y2, iterations - 1);
    }
}