using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
namespace Models;


public class Tower
{
    private PlotModel plotModel;

    public Tower(PlotModel plotModel)
    {
        this.plotModel = plotModel;
    }

    public void DrawTowers()
    {
        plotModel.Series.Clear(); // Очищаем предыдущие серии

        // Задаем параметры для башен
        double towerWidth = 5; // Ширина башни
        double towerHeight = 7; // Высота башни
        double towerSpacing = 3; // Расстояние между башнями
        double baseY = 0; // Начальная Y позиция для башен

        for (int i = 0; i < 3; i++)
        {
            double towerX = i * towerSpacing; // Позиция по оси X

            // Рисуем башню (прямоугольник)
            var towerLines = new LineSeries
            {
                StrokeThickness = 1,
                Color = OxyColors.Gray
            };


            // Добавляем точки для рисования башни
            towerLines.Points.Add(new DataPoint(towerX - towerWidth / 2, baseY)); // Bottom left
            towerLines.Points.Add(new DataPoint(towerX - towerWidth / 2, baseY + towerHeight)); // Top left
            towerLines.Points.Add(new DataPoint(towerX + towerWidth / 2, baseY + towerHeight)); // Top right
            towerLines.Points.Add(new DataPoint(towerX + towerWidth / 2, baseY)); // Bottom right
            towerLines.Points.Add(new DataPoint(towerX - towerWidth / 2, baseY)); // Closing the polygon

            plotModel.Series.Add(towerLines); // Add the tower to the plot
        }

        plotModel.InvalidatePlot(true); // Обновляем график
    }
}