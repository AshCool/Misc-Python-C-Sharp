using System;
using static System.Math;

namespace useless
{
    class Program
    {

        static int Fib(int number)
        {
            switch (Abs(number))
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    if (number > 0)
                        return Fib(number - 1) + Fib(number - 2);
                    else
                        return Fib(number + 2) - Fib(number + 1);
            }
        }

        static int NonRecursiveFib(int number)
        {
            switch (Abs(number))
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    if (number > 0)
                    {
                        int res = 1;
                        int fib1 = 1, fib2 = 1;
                        int i = 2;
                        while (i < number)
                        {
                            res = fib2 + fib1;
                            fib1 = fib2;
                            fib2 = res;
                            i++;
                        }
                        return res;
                    }
                    else
                    {
                        int res = -1;
                        int fib1 = 1, fib2 = -1;
                        int i = -2;
                        while (i > number)
                        {
                            res = fib1 - fib2;
                            fib1 = fib2;
                            fib2 = res;
                            i--;
                        }
                        return res;
                    }
            }
        }

        static int[] Bubble_sort(int[] array, int order = 1)
        {
            // 1 - ascend, -1 - descend, else - default
            if (order != 1)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[i] < array[j])
                        {
                            int temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            int temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }

            return array;
        }

        static int[] Comb_sort(int[] array)
        {
            int array_len = array.Length;
            int gap;
            int swapped;
            if (array_len > 1)
            {
                gap = array_len * (10 / 13);
            }
            else gap = 0;

            while (gap != 0)
            {
                if ((gap > 8) && (gap < 11))
                {
                    gap = 11;
                }
                swapped = 0;

                for (int i = 0; i < array_len - gap; i++)
                {
                    if (array[i + gap] < array[i])
                    {
                        int temp = array[i];
                        array[i] = array[i + gap];
                        array[i + gap] = temp;
                        swapped = 1;
                    }
                    gap = gap * (10 / 13);
                    if (gap == 0) gap = swapped;
                }

            }
            Array.Reverse(array);
            return array;
        }

        static int[] Insert_sort(int[] array)
        {
            int i;
            int key;
            for (int j = 1; j < array.Length; j++)
            {
                key = array[j];
                i = j - 1;

                while ((i >= 0) && (array[i] > key))
                {
                    array[i + 1] = array[i];
                    i--;
                }
                array[i + 1] = key;
            }

            return array;
        }

        static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];

            for (int i = 0; i < left.Length; i++)
            {
                result[i] = left[i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                result[left.Length + i] = right[i];
            }

            return result;
        }

        static int[] Merge_sort(int[] array)
        {
            if (array.Length <= 1) return array;

            int[] left = new int[array.Length / 2];
            int[] right = new int[array.Length - array.Length / 2];

            int middle = array.Length / 2;

            for (int i = 0; i < middle; i ++)
            {
                left[i] = array[i];
            }

            for (int i = middle; i < array.Length; i ++)
            {
                right[i - middle] = array[i];
            }

            left = Merge_sort(left);
            right = Merge_sort(right);
            int[] result = Merge(left, right);

            return result;
        }

        static int Binary_search(int[] array, int item)
        {
            if (array.Length == 0) return -1;

            int lower_bound = 0;
            int upper_bound = array.Length;
            int index;

            while (lower_bound != upper_bound)
            {
                index = (lower_bound + upper_bound) / 2;
                if (array[index] == item) return index;
                if (array[index] > item) upper_bound = index;
                else lower_bound = index;
            }

            return -1;
        }

        static double F(double x) { return Pow(x, 2) + 3 * x + 2; }

        static double Trapeze(double a, double b, double e=1.0)
        {
            int n = 1;
            double dx = (b - a) / n;
            double s = dx * (F(a) + 4 * F(a + dx / 2) + F(b)) / 6;
            double s1 = s + 2 * e;  // make sure next cycle will run
            double xa, xb;

            while (Abs(s-s1) > Abs(e))
            {
                n *= 2;
                s1 = s;
                s = 0;
                dx = (b - a) / n;

                for (int i = 0; i < n-1; i++)
                {
                    xa = a + dx * i;
                    xb = a + dx * (i + 1);
                    s = s + 0.5 * dx * (F(xa) + F(xb));
                }
            }

            return s;
        }

        static double Simpson(double a, double b, double e = 1.0)
        {
            int n = 1;
            double dx = (b - a) / n;
            double s = dx * (F(a) + 4 * F(a + dx / 2) + F(b)) / 6;
            double s1 = s + 2 * e;  // make sure next cycle will run
            double xa, xb, xab;

            while (Abs(s - s1) > Abs(e))
            {
                n *= 2;
                s1 = s;
                s = 0;
                dx = (b - a) / n;

                for (int i = 0; i < n - 1; i++)
                {
                    xa = a + dx * i;
                    xb = a + dx * (i + 1);
                    xab = xa + dx / 2;
                    s = s + dx * (F(xa) + 4 * F(xab) + F(xb)) / 6;
                }
            }

            return s;
        }

        static double Df(double x, double y) { return Pow(x, 2) - 2 * y; }

        static double Euler(double a, double b, double ya, int step_count)
        {
            double h = (b - a) / step_count;
            double y = ya;
            double fx;

            for (int i = 0; i < step_count; i++)
            {
                fx = Df(a + i * h, y);
                y = y + fx * h;
            }

            return y;
        }

        static double Modify_Euler(double a, double b, double ya, int step_count)
        {
            double h = (b - a) / step_count;
            double y = ya;
            double fx, fxx;

            for (int i = 0; i < step_count; i++)
            {
                fx = Df(a + i * h, y);
                fxx = Df(a + (i + 0.5) * h, y + 0.5 * h * fx);
                y = y + fxx * h;
            }

            return y;
        }

        static double Runge_Kutta(double a, double b, double ya, int step_count)
        {
            double h = (b - a) / step_count;
            double y = ya;
            double k1, k2, k3, k4;

            for (int i = 0; i < step_count; i++)
            {
                k1 = Df(a + i * h, y);
                k2 = Df(a + (i + 0.5) * h, y + k1 * h/2);
                k3 = Df(a + (i + 0.5) * h, y + k2 * h / 2);
                k4 = Df(a + (i + 1) * h, y + k3 * h);
                y = y + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
            }

            return y;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("fib(0): " + Fib(0));
            Console.WriteLine("non_recursive_fib(20): " + NonRecursiveFib(20));
            int[] array = { 8, -3, 8 };
            Console.Write("bubble_sort([8, -3, 8]) # ascend: ");
            int[] sorted = Bubble_sort(array);
            for (int i = 0; i < sorted.Length; i++)
            {
                Console.Write(sorted[i] + " ");
            }
            Console.WriteLine();
            Console.Write("bubble_sort([8, -3, 8) # descend: ");
            sorted = Bubble_sort(array, -1);
            for (int i = 0; i < sorted.Length; i++)
            {
                Console.Write(sorted[i] + " ");
            }
            Console.WriteLine();
            Console.Write("comb_sort([8, -5, -712, 457, 24]): ");
            sorted = Comb_sort(array);
            for (int i = 0; i < sorted.Length; i++)
            {
                Console.Write(sorted[i] + " ");
            }
            Console.WriteLine();
            int[] array2 = { 7, 7, 7, -8, 6 };
            Console.Write("insert_sort([7, 7, 7, -8, 6]): ");
            sorted = Insert_sort(array2);
            for (int i = 0; i < sorted.Length; i++)
            {
                Console.Write(sorted[i] + " ");
            }
            Console.WriteLine();
            Console.Write("merge_sort([7, 7, 7, -8, 6]): ");
            sorted = Merge_sort(array2);
            for (int i = 0; i < sorted.Length; i++)
            {
                Console.Write(sorted[i] + " ");
            }
            Console.WriteLine();
            int [] array3 =  { -5, -4, -3, 3, 4, 5 };
            Console.WriteLine("binary_search([-5, -4, -3, 3, 4, 5], -4): " + Binary_search(array3, -4));
            Console.WriteLine("trapeze(7, 8, 0.1) (f(x) = x**2 + 3*x + 2): " + Trapeze(7, 8, 0.1));
            Console.WriteLine("simpson(7, 8, 0.1) (f(x) = x**2 + 3*x + 2): " + Simpson(7, 8, 0.1));
            Console.WriteLine("euler(-5, 5, 0, 50): " + Euler(-5, 5, 0, 50));
            Console.WriteLine("modify_euler(-5, 5, 0, 50): " + Modify_Euler(-5, 5, 0, 50));
            Console.WriteLine("runge_kutta(-5, 5, 0, 50): " + Runge_Kutta(-5, 5, 0, 50));
            Console.ReadKey();
        }
    }
}
