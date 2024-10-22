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
        plotModel.Series.Clear(); // Clear previous series

        // Tower parameters
        double towerWidth = 3;   // Width of the tower
        double towerHeight = 7;  // Height of the tower
        double towerSpacing = 15; // Spacing between the towers
        double baseY = 0;         // Y position for the base of the towers

        for (int i = 0; i < 3; i++)
        {
            double towerX = i * towerSpacing;

            var towerLines = new LineSeries
            {
                StrokeThickness = 2,
                Color = OxyColors.Gray
            };

            towerLines.Points.Add(new DataPoint(towerX - towerWidth / 2, baseY));
            towerLines.Points.Add(new DataPoint(towerX - towerWidth / 2, baseY + towerHeight));
            towerLines.Points.Add(new DataPoint(towerX + towerWidth / 2, baseY + towerHeight));
            towerLines.Points.Add(new DataPoint(towerX + towerWidth / 2, baseY));
            towerLines.Points.Add(new DataPoint(towerX - towerWidth / 2, baseY));
            plotModel.Series.Add(towerLines);
        }

        plotModel.InvalidatePlot(true); // Update the plot to show changes
    }
}