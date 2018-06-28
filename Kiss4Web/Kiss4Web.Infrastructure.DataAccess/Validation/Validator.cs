using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.DataAccess.Validation
{
    public class Validator
    {
        private readonly Container _container;
        private readonly IDictionary<Guid, IValidator> _cachedValidators = new Dictionary<Guid, IValidator>();

        public Validator(Container container)
        {
            _container = container;
        }

        public async Task<ValidationResult> Validate(object entity)
        {
            var entityType = entity.GetType();
            var validator = _cachedValidators.LookupAddIfMissing(entityType.GUID, () => GetValidatorFromContainer(entityType));
            if (validator != null)
            {
                return await validator.ValidateAsync(entity);
            }

            return null;
        }

        private IValidator GetValidatorFromContainer(Type entityType)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(entityType);
            var registration = _container.GetRegistration(validatorType);
            return registration?.GetInstance() as IValidator;
        }
    }
}