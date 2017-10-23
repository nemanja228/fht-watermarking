using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHTWatermarking
{
    public class FibonacciSequence
    {
        private List<int> fibonacciPSequence;
        public int p;
        public int N;

        private FibonacciSequence(int p, int N, List<int> sequence)
        {
            this.p = p;
            this.N = N;
            fibonacciPSequence = sequence;
        }

        public static FibonacciSequence GetSequence(int p, int targetElement)
        {
            List<int> fib = new List<int>();
            fib.Add(1);

            int i = 1;
            while (fib[i - 1] < targetElement)
            {
                int offset = i - 1 - p;

                if (offset < 0)
                    fib.Add(fib[i - 1]);
                else if (offset == 0)
                    fib.Add(fib[i - 1] + 1);
                else
                    fib.Add(fib[i - 1] + fib[i - 1 - p]);

                i++;
            }

            return new FibonacciSequence(p, targetElement, fib);
        }

        public static List<int> UsableSequences(int number)
        {
            List<int> sequences = new List<int>();
            FibonacciSequence currentFib;
            for (int i = 0; i < number; i++)
            {
                currentFib = GetSequence(i, number);
                int tmp = currentFib.GetElementByIndex(currentFib.GetLength() - 1);
                if (tmp == number)
                    sequences.Add(i);
            }
            return sequences;
        }

        public int GetLength()
        {
            return fibonacciPSequence.Count;
        }

        public int GetElementByIndex(int index)
        {
            if (index < fibonacciPSequence.Count)
            {
                if (index < 0)
                    return 0;
                else
                    return fibonacciPSequence[index];
            }
            else
                return -1;
        }

        public int IndexOfElement(int element)
        {
            return fibonacciPSequence.IndexOf(element);
        }
    }
}
