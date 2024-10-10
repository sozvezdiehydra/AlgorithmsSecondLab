using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
namespace Fractals;
using AbstractClasses;

public class Julia : Algorithms
    {
        private readonly double cReal; // real part
        private readonly double cImag; // imagine part
        private readonly int maxIterations;
        private readonly double xMin, xMax, yMin, yMax;

        public Julia(double cReal, double cImag, double xMin, double xMax, double yMin, double yMax, int maxIterations)
        {
            this.cReal = cReal;
            this.cImag = cImag;
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
            this.maxIterations = maxIterations;
        }

        // override draw
        public override void Draw(PlotModel plotModel)
        {
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
            
            // color axis
            var colorAxis = new LinearColorAxis
            {
                Position = AxisPosition.Right,
                Palette = OxyPalettes.Hot(maxIterations),
                Minimum = 0,
                Maximum = maxIterations,
                IsAxisVisible = false
            };
            
            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);
            plotModel.Axes.Add(colorAxis);

            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle, MarkerSize = 1 };
            DrawJulia(scatterSeries, xMin, xMax, yMin, yMax, maxIterations);
            plotModel.Series.Add(scatterSeries);
        }
        
        private void DrawJulia(ScatterSeries scatterSeries, double x1, double x2, double y1, double y2, int iterations)
        {
            for (double x = x1; x <= x2; x += 0.005)
            {
                for (double y = y1; y <= y2; y += 0.005)
                {
                    int iterCount = GetJuliaIterations(x, y);
                    scatterSeries.Points.Add(new ScatterPoint(x, y, 1, iterCount));
                }
            }
        }
        
        private int GetJuliaIterations(double x, double y)
        {
            double zx = x;
            double zy = y;
            int iteration = 0;

            while (zx * zx + zy * zy < 4 && iteration < maxIterations)
            {
                double tempX = zx * zx - zy * zy + cReal;
                zy = 2 * zx * zy + cImag;
                zx = tempX;
                iteration++;
            }
            
            return iteration;
        }
    }
