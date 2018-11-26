using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No6
{
    public static class SequenceGenerator
    {
        public static IEnumerable<T> Generate<T>(Func<T, T, T> counter, int n, T firstElement, T secondElement)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }

            if (n >= 1)
            {
                yield return firstElement;    
                        
                if (n >= 2)
                {
                    yield return secondElement;   
                                 
                    T result;
                    for (int i = 2; i < n; i++)
                    {
                        result = counter(firstElement, secondElement);
                        firstElement = secondElement;
                        secondElement = result;
                        yield return secondElement;
                    }
                }
            }
        }
    }
}
