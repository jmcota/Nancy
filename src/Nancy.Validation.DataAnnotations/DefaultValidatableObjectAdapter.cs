﻿namespace Nancy.Validation.DataAnnotations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Default adapter for models that implements the <see cref="IValidatableObject"/> interface.
    /// </summary>
    public class DefaultValidatableObjectAdapter : IValidatableObjectAdapter
    {
        /// <summary>
        /// Validates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> instance, containing <see cref="ModelValidationError"/> objects.</returns>
        public IEnumerable<ModelValidationError> Validate(object instance)
        {
            var validateable =
                instance as IValidatableObject;

            if (validateable == null)
            {
                return Enumerable.Empty<ModelValidationError>();
            }

            var context =
                new ValidationContext(instance, null, null);

            var result =
                validateable.Validate(context);

            return result.Select(r => new ModelValidationError(r.MemberNames, r.ErrorMessage));
        }
    }
}