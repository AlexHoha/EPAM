﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Calculator
    {
        public double CalculateAverage(List<double> values, AveragingMethod averagingMethod)
        {
            if (values == null)
            {
                throw  new ArgumentNullException(nameof(values));
            }

            switch (averagingMethod)
            {
                case AveragingMethod.Mean:
                    return CalculateMean(values);

                case AveragingMethod.Median:
                    return CalculateMedian(values);

                default:
                    throw new ArgumentException("Invalid averagingMethod value");
            }
        }

        double CalculateMean(List<double> values)
        {
            return values.Sum() / values.Count;
        }

        double CalculateMedian(List<double> values)
        {
            var sortedValues = values.OrderBy(x => x).ToList();

            int n = sortedValues.Count;

            if (n % 2 == 1)
            {
                return sortedValues[(n - 1) / 2];
            }

            return (sortedValues[sortedValues.Count / 2 - 1] + sortedValues[n / 2]) / 2;
        }

        public double CalculateAverage(Mathematician mathematician, List<double> values)
        {
            return mathematician.Calculate(values);
        }
    }
}
