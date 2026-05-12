using System;

namespace ProjectFiles.Core.Utils
{
    public static class NumberFormatter
    {
        private static readonly string[] Suffixes = { "", "k", "M", "B", "T", "Qa", "Qi" };

        public static string ToFormattedString(this float value)
        {
            if (value < 1000) 
                return value.ToString("0"); 

            int suffixIndex = 0;
            double tempValue = value;

            while (tempValue >= 1000 && suffixIndex < Suffixes.Length - 1)
            {
                tempValue /= 1000;
                suffixIndex++;
            }

            return $"{tempValue:F1}{Suffixes[suffixIndex]}";
        }
    }
}