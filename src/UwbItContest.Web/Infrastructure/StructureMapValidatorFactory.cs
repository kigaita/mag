using System;
using FluentValidation;
using UwbItContest.Web.App_Start;

namespace UwbItContest.Web.Infrastructure
{
    public class StructureMapValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType) => 
            StructuremapMvc
                .StructureMapDependencyScope
                .CurrentNestedContainer
                .GetInstance<IValidator>();
    }
}