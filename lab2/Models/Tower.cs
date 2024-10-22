using System.Windows;
using System.Windows.Shapes;
using AbstractClasses;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
namespace Models;


public class Tower : Algorithms
{
    private PlotModel plotModel;

    public Tower(PlotModel plotModel)
    {
        this.plotModel = plotModel;
    }

    public override void Draw(PlotModel plotModel)
    {
        //
    }
    public async void AnimateTowerOfHanoi(int numberOfDisks, int timeForDelay)
    {
        List<Stack<int>> towers = new List<Stack<int>>
        {
            new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse()), // Tower 0 (source) holds all disks initially
            new Stack<int>(), // Tower 1 (auxiliary) starts empty
            new Stack<int>()  // Tower 2 (target) starts empty
        };

        await MoveDisks(numberOfDisks, 0, 2, 1, towers, timeForDelay);
    }

    private async Task MoveDisks(int n, int source, int target, int auxiliary, List<Stack<int>> towers, int timeForDelay)
    {
        if (n > 0)
        {
            // Move n-1 disks from source to auxiliary using target as auxiliary
            await MoveDisks(n - 1, source, auxiliary, target, towers, timeForDelay);

            towers[target].Push(towers[source].Pop());

            DrawTowersAndDisks(towers);
            plotModel.InvalidatePlot(true);

            await Task.Delay(timeForDelay);

            await MoveDisks(n - 1, auxiliary, target, source, towers, timeForDelay);
        }
    }
    public int CalculateHanoiSteps(int numberOfDisks)
    {
        return (int)Math.Pow(2, numberOfDisks) - 1;
    }

    public void DrawTowersAndDisks(List<Stack<int>> towers)
    {
        plotModel.Series.Clear();
        // tower
        double towerWidth = 3;
        double towerHeight = 7;
        double towerSpacing = 15;
        double baseY = 0;
        // disks
        double diskHeight = 0.5;
        double diskSpacing = 0.1;
        // delete the axis
        AddAxes(plotModel);
        // draw a towers
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

        for (int i = 0; i < 3; i++)
        {
            double towerX = i * towerSpacing;

            int diskCount = towers[i].Count;
            double currentY = baseY;

            foreach (int diskSize in towers[i])
            {
                double diskWidth = 10 - diskSize * 1.5;

                var diskLines = new LineSeries
                {
                    StrokeThickness = 2,
                    Color = OxyColors.Blue
                };

                diskLines.Points.Add(new DataPoint(towerX - diskWidth / 2, currentY));            // Bottom left
                diskLines.Points.Add(new DataPoint(towerX - diskWidth / 2, currentY + diskHeight)); // Top left
                diskLines.Points.Add(new DataPoint(towerX + diskWidth / 2, currentY + diskHeight)); // Top right
                diskLines.Points.Add(new DataPoint(towerX + diskWidth / 2, currentY));            // Bottom right
                diskLines.Points.Add(new DataPoint(towerX - diskWidth / 2, currentY));            // Close the rectangle

                plotModel.Series.Add(diskLines);

                // update Y position for the next disk
                currentY += diskHeight + diskSpacing;
            }
        }

        plotModel.InvalidatePlot(true); // update the plot to display changes
    }
}