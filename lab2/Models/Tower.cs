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
    private List<List<Stack<int>>> stepsList = new List<List<Stack<int>>>();
    private int currentStep = 0;
    private bool isPaused = false;


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
        stepsList.Clear(); 
        currentStep = 0;

        List<Stack<int>> towers = new List<Stack<int>>
        {
            new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse()), // Tower 0 (source) holds all disks initially
            new Stack<int>(), // Tower 1 (auxiliary) starts empty
            new Stack<int>()  // Tower 2 (target) starts empty
        };

        SaveCurrentState(towers); // Сохранить начальное состояние

        int steps = CalculateHanoiSteps(numberOfDisks);
        if(numberOfDisks == 2)
        {
            MessageBox.Show($"Для {numberOfDisks} дисков, нужно {steps} шага");
        }
        else
        {
            MessageBox.Show($"Для {numberOfDisks} дисков, нужно {steps} шагов");
        }
        await MoveDisks(numberOfDisks, 0, 2, 1, towers, timeForDelay);
    }

    private async Task MoveDisks(int n, int source, int target, int auxiliary, List<Stack<int>> towers, int timeForDelay)
    {
        if (n > 0)
        {
            await MoveDisks(n - 1, source, auxiliary, target, towers, timeForDelay);

            towers[target].Push(towers[source].Pop());
            SaveCurrentState(towers);
            DrawTowersAndDisks(towers);
            plotModel.InvalidatePlot(true);

            // Ждем, если пауза включена
            while (isPaused)
            {
                await Task.Delay(100);
            }

            await Task.Delay(timeForDelay);

            await MoveDisks(n - 1, auxiliary, target, source, towers, timeForDelay);
        }
    }
    private void SaveCurrentState(List<Stack<int>> towers)
    {
        var copy = new List<Stack<int>>();
        foreach (var tower in towers)
        {
            copy.Add(new Stack<int>(new Stack<int>(tower)));
        }
        stepsList.Add(copy);
    }

    public int CalculateHanoiSteps(int numberOfDisks)
    {
        return (int)Math.Pow(2, numberOfDisks) - 1;
    }

    public void DrawTowersAndDisks(List<Stack<int>> towers)
    {
        plotModel.Series.Clear();
        plotModel.Annotations.Clear();

        // tower
        double towerWidth = 3;
        double towerHeight = 7;
        double towerSpacing = 15;
        double baseY = 0;

        // disks
        double diskHeight = 0.5;
        double diskSpacing = 0.1;

        int maxDiskCount = towers.Max(t => t.Count);

        double maxDiskWidth = 10;
        double minDiskWidth = 2;

        // Axis removal
        AddAxes(plotModel);

        // Draw towers
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

        // Draw disks
        for (int i = 0; i < 3; i++)
        {
            double towerX = i * towerSpacing;

            int diskCount = towers[i].Count;
            double currentY = baseY;

            foreach (int diskSize in towers[i].Reverse())
            {
                double diskWidth = minDiskWidth + ((maxDiskWidth - minDiskWidth) * (diskSize - 1)) / (maxDiskCount - 1);

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

                var diskLabel = new TextAnnotation
                {
                    Text = diskSize.ToString(),
                    TextPosition = new DataPoint(towerX, currentY + diskHeight / 2),
                    FontSize = 15,
                    Stroke = OxyColors.Transparent, // No border around the text
                    TextColor = OxyColors.Black,    // Color of the text
                    TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center,
                    TextVerticalAlignment = OxyPlot.VerticalAlignment.Middle
                };

                plotModel.Annotations.Add(diskLabel);

                currentY += diskHeight + diskSpacing;
            }
        }

        plotModel.InvalidatePlot(true);
    }

    public void StepForward()
    {
        if (currentStep < stepsList.Count - 1)
        {
            currentStep++;
            DrawTowersAndDisks(stepsList[currentStep]);
        }
    }

    public void StepBackward()
    {
        if (currentStep > 0)
        {
            currentStep--;
            DrawTowersAndDisks(stepsList[currentStep]);
        }
    }

}