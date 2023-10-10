namespace ProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            long res=0,x,n, t = long.Parse(Console.ReadLine());
            while (t > 0)
            {
                n = long.Parse(Console.ReadLine());
                long[] nums= new long[n];
                for (int i = 0; i < n; i++)
                    nums[i]=long.Parse(Console.ReadLine());
                x = long.Parse(Console.ReadLine());

                for (int i = 0;i < nums.Length-1;i++)
                    for (int j = i+1;j < nums.Length;j++)
                        if (nums[i] + nums[j] == x)
                            res++;
            }
        }
    }
}