﻿using Prometheus;

namespace PrometheusDemo.CustomMetrics
{
    public static class RandomNumberMetrics
    {
        public static readonly Histogram RandomNumberDuration = Metrics.CreateHistogram("random_number_duration_seconds", "Measures the duration of random number generation in seconds.");

        public static readonly Counter DigitCount = Metrics.CreateCounter("random_number_digit_count", "Measures the count of digits generated by the random number generator.");
        public static readonly Counter EvenNumberCount = Metrics.CreateCounter("random_number_even_count", "Measures the count of even numbers generated by the random number generator.");
        public static readonly Counter OddNumberCount = Metrics.CreateCounter("random_number_odd_count", "Measures the count of odd numbers generated by the random number generator.");
        public static readonly Counter SevenDigitCount = Metrics.CreateCounter("random_number_seven_digit_count", "Measures the count of sevens generated by the random number generator.");
    }
}
