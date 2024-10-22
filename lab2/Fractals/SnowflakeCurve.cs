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
        var lineSeries = new LineSeries();

        // Рисуем первую сторону
        DrawSnowflakeCurve(lineSeries, x1, y1, x2, y2, iterations);
        lineSeries.Points.Add(new DataPoint(double.NaN, double.NaN)); // Разрыв между линиями

        // Вычисляем третью вершину равностороннего треугольника
        double x3 = (x1 + x2) / 2 + Math.Sqrt(3) * (y1 - y2) / 2; // X координата третьей вершины
        double y3 = (y1 + y2) / 2 + Math.Sqrt(3) * (x2 - x1) / 2; // Y координата третьей вершины

        // Рисуем вторую сторону
        DrawSnowflakeCurve(lineSeries, x2, y2, x3, y3, iterations);
        lineSeries.Points.Add(new DataPoint(double.NaN, double.NaN)); // Разрыв между линиями

        // Рисуем третью сторону
        DrawSnowflakeCurve(lineSeries, x3, y3, x1, y1, iterations);

        // Добавляем линию в модель графика
        plotModel.Series.Add(lineSeries);

        // Добавляем оси
        AddAxes(plotModel);
    }

    private void DrawSnowflakeCurve(LineSeries lineSeries, double x1, double y1, double x2, double y2, int iterations)
    {
        // Условие выхода из рекурсии
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

        // Вычисляем координаты "пиковой" точки
        double x5 = x3 + dx / 2 - Math.Sqrt(3) * dy / 2; // Поворот на 60 градусов
        double y5 = y3 + dy / 2 + Math.Sqrt(3) * dx / 2; // Поворот на 60 градусов

        DrawSnowflakeCurve(lineSeries, x1, y1, x3, y3, iterations - 1);
        lineSeries.Points.Add(new DataPoint(double.NaN, double.NaN)); // Разрыв между линиями
        DrawSnowflakeCurve(lineSeries, x3, y3, x5, y5, iterations - 1);
        lineSeries.Points.Add(new DataPoint(double.NaN, double.NaN)); // Разрыв между линиями
        DrawSnowflakeCurve(lineSeries, x5, y5, x4, y4, iterations - 1);
        lineSeries.Points.Add(new DataPoint(double.NaN, double.NaN)); // Разрыв между линиями
        DrawSnowflakeCurve(lineSeries, x4, y4, x2, y2, iterations - 1);
    }
}