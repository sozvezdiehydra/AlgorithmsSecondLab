using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Fractals
{
    public class Julia : Algorithms
    {
        private readonly double cReal; // Вещественная часть комплексного числа
        private readonly double cImag; // Мнимая часть комплексного числа
        private readonly int maxIterations; // Максимальное количество итераций
        private readonly double xMin, xMax, yMin, yMax; // Границы области для отображения фрактала

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

        // Переопределение метода Draw
        public override void Draw(PlotModel plotModel)
        {
            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle, MarkerSize = 1 };
            DrawJulia(scatterSeries, xMin, xMax, yMin, yMax, maxIterations);
            plotModel.Series.Add(scatterSeries);
        }

        // Рекурсивная функция для рисования фрактала Жюлиа
        private void DrawJulia(ScatterSeries scatterSeries, double x1, double x2, double y1, double y2, int iterations)
        {
            if (iterations == 0)
            {
                return;
            }

            // Проверяем координаты, чтобы получить точки для фрактала
            for (double x = x1; x <= x2; x += 0.005) // шаг для X
            {
                for (double y = y1; y <= y2; y += 0.005) // шаг для Y
                {
                    if (IsInJuliaSet(x, y))
                    {
                        scatterSeries.Points.Add(new ScatterPoint(x, y));
                    }
                }
            }
        }

        // Проверка, входит ли точка в фрактал Жюлиа
        private bool IsInJuliaSet(double x, double y)
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

            return iteration == maxIterations;
        }
    }
}
