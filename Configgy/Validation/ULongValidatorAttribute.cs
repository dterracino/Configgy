﻿using System;
using System.Linq;
using System.Reflection;

namespace Configgy.Validation
{
    /// <summary>
    /// An <see cref="IValueValidator"/> for <see cref="ulong"/>s.
    /// </summary>
    public class ULongValidatorAttribute : ValueValidatorAtributeBase, INumericishValidator<ulong>
    {
        /// <summary>
        /// The minimum value allowed by this validator.
        /// </summary>
        public ulong Min { get; protected set; }

        /// <summary>
        /// The maximum value allowed by this validator.
        /// </summary>
        public ulong Max { get; protected set; }

        /// <summary>
        /// The set of values allowed by this validator.
        /// </summary>
        public ulong[] ValidValues { get; protected set; }

        /// <summary>
        /// Creates a validator with default max and min values.
        /// </summary>
        public ULongValidatorAttribute()
        {
            Min = ulong.MinValue;
            Max = ulong.MaxValue;
        }

        /// <summary>
        /// Creates a validator with the given max and min values.
        /// </summary>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        public ULongValidatorAttribute(ulong min, ulong max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Creates a validator with the given set of valid values.
        /// </summary>
        /// <param name="validValues">The set of values to be considered valid; any other values will cause an exception.</param>
        public ULongValidatorAttribute(params ulong[] validValues)
            : this()
        {
            ValidValues = validValues;
        }

        /// <summary>
        /// Validate a potential value.
        /// This method must throw an exception if the value is invalid.
        /// </summary>
        /// <typeparam name="T">The type the value is expected to be coerced into.</typeparam>
        /// <param name="value">The raw string value.</param>
        /// <param name="valueName">The name of the value.</param>
        /// <param name="property">If this value is directly associated with a property on a <see cref="Config"/> instance this is the reference to that property.</param>
        /// <returns>
        ///     If the validator also coerced the value in the process of validation it may return that value upon successful validation.
        ///     If the validator did not coerce the value but did validate successfully it should return null.
        ///     If the validator did not successfully validate the value it should throw an exception, preferably <see cref="Exceptions.ValidationException"/>.
        /// </returns>
        /// <exception cref="Exceptions.ValidationException">Thrown when the value is not valid.</exception>
        public override object Validate<T>(string value, string valueName, PropertyInfo property)
        {
            var val = ulong.Parse(value);

            if (val < Min || val > Max)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            if (ValidValues != null && !ValidValues.Contains(val))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return val;
        }
    }
}
