class MonteCarlo
{
    private int A;
    private int B;
    private int count;
    private readonly Random  rnd = new ();
    
    public  MonteCarlo(int a, int b)
    {
        A = a;
        B = b;
        count = 10000;
    }
    
    private double F(double x)
    {
        return Math.Pow(x, 3);
    }

    private double[][] GetCoords()
    {
        double [][] coords = new double[count][];
        for (int i = 0; i < count; i++)
        {
            coords[i] =
            [
                A + rnd.NextDouble() * (B - A),
                rnd.NextDouble() * F(B)
            ];
        }
        return coords;
    }

    public double[] Shots()
    {
        double [] shots = new double[2];
        double[][] coords = GetCoords();
        for (int i = 0; i < count; i++)
            
        {
            // shots[0] = mimo
            if (F(coords[i][0]) < coords[i][1])
            {
                shots[0]++;
            }
            // shots[1] = trefa
            else
            {
                shots[1]++;
            }
        }
        return shots;
    }

    public double Sintegral()
    {
        double[] shots = Shots();
        return shots[1] / (shots[0] + shots[1]) * F(B) * (B - A);
    }
}
class Program
{
    static void Main()
    {
        MonteCarlo integral = new MonteCarlo(1,4);
        Console.WriteLine(integral.Sintegral()); 
        

    }
}