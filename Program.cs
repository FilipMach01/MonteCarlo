using System.Diagnostics;

class MonteCarlo
{
    private readonly int _a;
    private readonly int _b;
    private readonly Random _rnd = new();

    public MonteCarlo(int a, int b)
    {
        _a = a;
        _b = b;
    }

    private static double F(double x)
    {
        return Math.Pow(x, 3);
    }

    private void GeneratePoints(out  int hits, out int misses)
    {
        var duration = TimeSpan.FromSeconds(3);
        var stopwatch = Stopwatch.StartNew();
        
        hits = 0;
        misses = 0;
        
        while (stopwatch.Elapsed < duration)
        { 
            double x = _a + _rnd.NextDouble() * (_b - _a);
            double y = _rnd.NextDouble() * F(_b);
            
            if (F(x) > y)
            {
                hits++;
            }
            else
            {
                misses++;
            }
        }
    }

    public double Integrate()
    {
        GeneratePoints(out int  hits, out int misses);
        double hitRatio = hits / ((double)misses + hits);
        double squareArea = (_b - _a) * F(_b);
        return hitRatio * squareArea;

    }
}


class Program
{
    private static void Main()
    {
        MonteCarlo integral = new MonteCarlo(4,5);
        Console.WriteLine(integral.Integrate());
    }
}