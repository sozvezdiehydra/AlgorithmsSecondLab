﻿using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
namespace Fractals;
using AbstractClasses;

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
        lineSeries.Color = OxyColors.RosyBrown;
        DrawPythagorasTree(lineSeries, x1, y1, length, angle, iterations);
        AddAxes(plotModel);
        plotModel.Series.Add(lineSeries);
    }

    private void DrawPythagorasTree(LineSeries lineSeries, double x1, double y1, double length, double angle, double iterations)
    {
        if (iterations == 0 || length < 0.01)
        {
            return;
        }

        // Вычисляем конечные координаты ветви
        double x2 = x1 + length * Math.Cos(angle);
        double y2 = y1 - length * Math.Sin(angle);

        // Добавляем линию в LineSeries
        lineSeries.Points.Add(new DataPoint(x1, y1));
        lineSeries.Points.Add(new DataPoint(x2, y2));
        lineSeries.Points.Add(new DataPoint(double.NaN, double.NaN));

        // Рекурсивно рисуем левую и правую ветви
        double newLength = length * 0.7; // Уменьшаем длину для каждой новой ветви
        double deltaAngle = Math.PI / 4; // Угол наклона для новых ветвей

        DrawPythagorasTree(lineSeries, x2, y2, newLength, angle + deltaAngle, iterations - 1);
        DrawPythagorasTree(lineSeries, x2, y2, newLength, angle - deltaAngle, iterations - 1);
    }
}