using System;
using System.Collections.Generic;
using System.Text;


namespace Domain._01_TDD.Metric_Converter
{
    public interface IConverter
    {
        public double Convert(IMetricConversionType unitType, double value);
    }
}
