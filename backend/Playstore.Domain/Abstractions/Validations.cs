using System.Text.RegularExpressions;
using Playstore.Domain.Exceptions;

namespace Playstore.Domain.Abstractions
{
    public class Validations
    {
        #region Public Static Methods

        public static void ValidateIsNot(object firstObject, object secondObject, string errorMessage)
        {
            if (!firstObject.Equals(secondObject))
                throw new DomainException(errorMessage);
        }

        public static void ValidateIs(object firstObject, object secondObject, string errorMessage)
        {
            if (firstObject.Equals(secondObject))
                throw new DomainException(errorMessage);
        }

        public static void ValidateStringLength(string value, int maximum, string errorMessage)
        {
            if (value.Trim().Length > maximum)
                throw new DomainException(errorMessage);
        }

        public static void ValidateStringRange(string value, int minimum, int maximum, string errorMessage)
        {
            var valueSize = value.Trim().Length;
            if (valueSize < minimum || valueSize > maximum)
                throw new DomainException(errorMessage);
        }

        public static void ValidateRegex(string expression, string value, string errorMessage)
        {
            var regex = new Regex(expression);
            if (!regex.IsMatch(value))
                throw new DomainException(errorMessage);
        }

        public static void ValidateNotEmpty(string value, string errorMessage)
        {
            if (value == null || value.Trim().Length == 0)
                throw new DomainException(errorMessage);
        }

        public static void ValidateNotNull(object firstObject, string errorMessage)
        {
            if (firstObject == null)
                throw new DomainException(errorMessage);
        }

        public static void ValidateDoubleRange(double value, double minimum, double maximum, string errorMessage)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(errorMessage);
        }

        public static void ValidateFloatRange(float value, float minimum, float maximum, string errorMessage)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(errorMessage);
        }

        public static void ValidateIntRange(int value, int minimum, int maximum, string errorMessage)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(errorMessage);
        }

        public static void ValidateLongRange(long value, long minimum, long maximum, string errorMessage)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(errorMessage);
        }

        public static void ValidateDecimalMinimum(decimal value, decimal minimum, string errorMessage)
        {
            if (value <= minimum)
                throw new DomainException(errorMessage);
        }

        public static void ValidateLongMinimum(long value, long minimum, string errorMessage)
        {
            if (value <= minimum)
                throw new DomainException(errorMessage);
        }

        public static void ValidateDoubleMinimum(double value, double minimum, string errorMessage)
        {
            if (value <= minimum)
                throw new DomainException(errorMessage);
        }

        public static void ValidateFloatMinimum(float value, float minimum, string errorMessage)
        {
            if (value <= minimum)
                throw new DomainException(errorMessage);
        }

        public static void ValidateIntMinimum(int value, int minimum, string errorMessage)
        {
            if (value <= minimum)
                throw new DomainException(errorMessage);
        }

        public static void ValideIsFalse(bool value, string errorMessage)
        {
            if (value)
                throw new DomainException(errorMessage);
        }

        public static void ValideIsTrue(bool value, string errorMessage)
        {
            if (!value)
                throw new DomainException(errorMessage);
        }

        #endregion
    }
}