using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Mathematician : IMathematician
    {
        private AveragingMethod averagingMethod;
        public Mathematician(AveragingMethod averagingMethod)
        {
            this.averagingMethod = averagingMethod;
        }

        public double Calculate(List<double> list)
        {

            switch(averagingMethod)
            {
                case AveragingMethod.Mean : 
                    {
                        return list.Sum() / list.Count;
                    }
                case AveragingMethod.Median:
                    {
                        var sortedValues = list.OrderBy(x => x).ToList();

                        int n = sortedValues.Count;

                        if (n % 2 == 1)
                        {
                            return sortedValues[(n - 1) / 2];
                        }

                        return (sortedValues[sortedValues.Count / 2 - 1] + sortedValues[n / 2]) / 2;
                    }
                default:
                    {
                        return 0;
                    }

            }
        }
    }
}
