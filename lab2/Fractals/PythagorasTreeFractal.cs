using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;

namespace lab2.Fractals;

public class PythagorasTreeFractal : Algorithms
{
    private double x1, y1, length;
    private double angle;
    private double iterations;

    public PythagorasTreeFractal(double x1, double y1, double length, double angle, double iterations)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.length = length;
        this.angle = angle;
        this.iterations = iterations;
    }

    public override void Draw(PlotModel plotModel)
    {
        var lineSeries = new LineSeries();
        DrawPythagorasTree(lineSeries, x1, y1, length, angle, iterations);
        plotModel.Series.Add(lineSeries);
    }

    private void DrawPythagorasTree(LineSeries lineSeries, double x1, double y1, double length, double angle, double iterations)
    {
        if (iterations == 0)
        {
            return;
        }
        
        double x2 = x1 + iterations * Math.Cos(angle);
        double y2 = y1 - iterations * Math.Sin(angle);
        
        lineSeries.Points.Add(new DataPoint(x1, y1));
        lineSeries.Points.Add(new DataPoint(x2, y2));
        lineSeries.Points.Add(new DataPoint(double.NaN, double.NaN));
        
        DrawPythagorasTree(lineSeries, x2, y2, length * 0.5, angle + Math.PI / 8, iterations - 1);
        DrawPythagorasTree(lineSeries, x2, y2, length * 0.5, angle - Math.PI / 8, iterations - 1);
        
    }

}