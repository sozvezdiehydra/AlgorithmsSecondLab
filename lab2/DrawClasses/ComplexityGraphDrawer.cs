using OxyPlot.Series;
using OxyPlot;

namespace lab2.DrawClasses
{
    public class ComplexityGraphDrawer
    {
        private PlotModel complexityPlotModel;

        public ComplexityGraphDrawer(PlotModel complexityPlotModel)
        {
            this.complexityPlotModel = complexityPlotModel;
        }

        public void DrawComplexityGraph(int maxDisks)
        {
            complexityPlotModel.Series.Clear();

            // Добавляем линию графика
            var lineSeries = new LineSeries
            {
                Title = "Сложность Ханойских Башен",
                StrokeThickness = 2,
                Color = OxyColors.Blue
            };

            // Строим точки на основе формулы 2^n - 1
            for (int n = 1; n <= maxDisks; n++)
            {
                int steps = (int)Math.Pow(2, n) - 1; // Сложность Ханойской башни
                lineSeries.Points.Add(new DataPoint(n, steps));
            }

            complexityPlotModel.Series.Add(lineSeries);

            // Настраиваем оси
            complexityPlotModel.Axes.Clear();
            complexityPlotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Title = "Количество дисков",
                Minimum = 1,
                Maximum = maxDisks
            });

            complexityPlotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Количество шагов",
                Minimum = 0
            });

            complexityPlotModel.InvalidatePlot(true); // Обновить график
        }
    }
}
