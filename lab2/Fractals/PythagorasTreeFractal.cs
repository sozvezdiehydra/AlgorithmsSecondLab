using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;

namespace lab2.Fractals;

public class PythagorasTreeFractal : Algorithms
{
    private double x1, y1, length;
    private double angle;
    private double iteration;

    public PythagorasTreeFractal(double x1, double y1, double length, double angle, double iteration)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.length = length;
        this.angle = angle;
        this.iteration = iteration;
    }

    public override void Draw(PlotModel plotModel)
    {
        var lineSeries = new LineSeries();
        DrawPythagorasTree(lineSeries, x1, y1, length, angle, iteration);
        plotModel.Series.Add(lineSeries);
    }

    private void DrawPythagorasTree(LineSeries lineSeries, double x1, double y1, double length, double angle, double iteration)
    {
        if (iteration == 0)
        {
            return;
        }
        
        double x2 = x1 + iteration * Math.Cos(angle);
        double y2 = y1 - iteration * Math.Sin(angle);
        
        lineSeries.Points.Add(new DataPoint(x1, y1));
        lineSeries.Points.Add(new DataPoint(x2, y2));
        
        DrawPythagorasTree(lineSeries, x2, y2, length * 0.5, angle + Math.PI / 8, iteration - 1);
        DrawPythagorasTree(lineSeries, x2, y2, length * 0.5, angle - Math.PI / 8, iteration - 1);
        
    }

}