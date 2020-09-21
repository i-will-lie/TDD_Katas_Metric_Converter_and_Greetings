namespace Domain._01_TDD.Metric_Converter
{
    public interface IMetricConversionType
    {
        public double Convert(double value);
      
    }

    public class KilometerToMile: IMetricConversionType
    {
        public double Convert(double value)
        {
            return value * 0.621371;
        }
    }

    public class CelsiusToFahrenheit : IMetricConversionType
    {
        public double Convert(double value)
        {
            return (value * 1.8) + 32;
        }
    }

    public class KilogramToPound : IMetricConversionType
    {
        public double Convert(double kilogram)
        {
            return kilogram / 0.45359237;
        }
    }

    public class LiterToUkGallon : IMetricConversionType
    {
        public double Convert(double liters)
        {
            return liters / 4.54609;
        }
    }

    public class LiterToUsGallon : IMetricConversionType
    {
        public double Convert(double liter)
        {
            return liter / 3.785411784;
        }
    }

}
