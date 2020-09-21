using System;



namespace Domain._01_TDD.Metric_Converter
{
    public class MetricConverter : IConverter
    {


        public double Convert(IMetricConversionType unitType, double value)
        {
            if(unitType == null)
            {
                throw new ArgumentNullException(null,"\"null\" is not a valid MetricConversionType!");
            }
            return unitType.Convert(value);

        }
    }
   
}