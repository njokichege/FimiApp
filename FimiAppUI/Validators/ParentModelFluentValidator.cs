﻿namespace FimiAppUI.Validators
{
    public class ParentModelFluentValidator : AbstractValidator<ParentModel>
    {
        [Inject] public IParentService ParentService { get; set; }
        public ParentModelFluentValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 100);
            RuleFor(x => x.MiddleName).NotEmpty().Length(1, 100);
            RuleFor(x => x.Surname).NotEmpty().Length(1, 100);
            RuleFor(x => x.NationalId).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ParentModel>.CreateWithOptions((ParentModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}