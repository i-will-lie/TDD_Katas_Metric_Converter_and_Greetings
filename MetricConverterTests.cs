using System;
using Domain._01_TDD.Metric_Converter;
using FluentAssertions;
using NUnit.Framework;

namespace Specs.Unit._01_TDD.Metric_Converter
{


    public class MetricConverterTests
    {

        private IConverter _metricConverter;
        [SetUp]
        public void Initialise_metric_converter_instance()
        {
            _metricConverter = new MetricConverter();
        }

        [Test]
        public void Newly_created_instance_converter_should_not_be_null()
        {
            _metricConverter.Should().NotBeNull();
        }

        [Test]
        public void Invalid_measurement_unit_should_throw_invalid_enum_argument_exception()                     
        {
            var value = 10;

            Action act = () => _metricConverter.Convert(null, value);

            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("\"null\" is not a valid MetricConversionType!");
        }

        [Test]
        public void Kilometers_should_convert_to_miles()
        {
            var kiloMeter = 1;
            var expectedMile = kiloMeter * 0.621371;

            var actualMile = _metricConverter.Convert(new KilometerToMile(), kiloMeter);

            actualMile.Should().BeApproximately(expectedMile, 0.000001F);


        }
        [Test]
        public void Celsius_should_convert_to_fahrenheit()
        {
            var celcius = 100;
            var expectedFahrenheit = (celcius * 1.8) + 32;

            var actualFahrenheit = _metricConverter.Convert(new CelsiusToFahrenheit(), celcius);

            actualFahrenheit.Should().BeApproximately(expectedFahrenheit, 0.000001F);

        }

        [Test]
        public void Kilograms_should_convert_to_pounds()
        {
            var kiloGram = 10;
            var expectedPound = kiloGram / 0.45359237;

            var actualPound = _metricConverter.Convert(new KilogramToPound(), kiloGram);

            actualPound.Should().BeApproximately(expectedPound, 0.000001F);
        }


        [Test]
        public void Liter_should_convert_to_uk_gallons()
        {
            var liters = 1.0;
            var expectedUkGallons = liters / 4.54609;

            var acutalUkGallon = _metricConverter.Convert(new LiterToUkGallon(), liters);

            acutalUkGallon.Should().BeApproximately(expectedUkGallons, 0.000001F);
        }

        [Test]
        public void Liter_should_convert_to_us_gallons()
        {
            var liter = 1.0;
            var expectedUsGallon = liter / 3.785411784;

            var actualUsGallon = _metricConverter.Convert(new LiterToUsGallon(), liter);

            actualUsGallon.Should().BeApproximately(expectedUsGallon, 0.000001F);

        }
    }
}
