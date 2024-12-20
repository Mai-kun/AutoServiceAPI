﻿using DeliveryOffice.API.Models.RequestModels;
using DeliveryOffice.Services.Validators.Product;
using FluentValidation.TestHelper;
using Xunit;

namespace DeliveryOffice.Services.Tests.Validators;

/// <summary>
///     Тесты для <see cref="CreateProductRequestValidator" />
/// </summary>
public class CreateProductRequestValidatorTests
{
    private readonly CreateProductRequestValidator validator = new ();

    [Fact]
    public void ShouldHaveValidationErrorForMaximumLength()
    {
        var model = new CreateProductRequest
        {
            Name = new string('a', 300),
            Unit = new string('a', 100),
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldHaveValidationErrorFor(member => member.Name);
        result.ShouldHaveValidationErrorFor(member => member.Unit);
    }

    [Fact]
    public void ShouldHaveValidationErrorForNull()
    {
        var model = new CreateProductRequest
        {
            Name = null,
            Unit = null,
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldHaveValidationErrorFor(member => member.Name);
        result.ShouldHaveValidationErrorFor(member => member.Unit);
    }

    [Fact]
    public void ShouldHaveValidationErrorForEmpty()
    {
        var model = new CreateProductRequest
        {
            Name = string.Empty,
            Unit = string.Empty,
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldHaveValidationErrorFor(member => member.Name);
        result.ShouldHaveValidationErrorFor(member => member.Unit);
    }

    [Fact]
    public void ShouldHaveValidationErrorForMinimumValue()
    {
        var model = new CreateProductRequest
        {
            Quantity = -100,
            Price = -50,
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldHaveValidationErrorFor(member => member.Quantity);
        result.ShouldHaveValidationErrorFor(member => member.Price);
    }

    /// <summary>
    ///     Отсутствие ошибки при корректных данных
    /// </summary>
    [Fact]
    public void ShouldHaveNoErrors()
    {
        var model = new CreateProductRequest
        {
            Name = "Platonist",
            Quantity = 50,
            Unit = "kg",
            Price = 25,
        };

        //Act
        var result = validator.TestValidate(model);

        //Assert
        result.ShouldNotHaveValidationErrorFor(member => member.Name);
        result.ShouldNotHaveValidationErrorFor(member => member.Quantity);
        result.ShouldNotHaveValidationErrorFor(member => member.Unit);
        result.ShouldNotHaveValidationErrorFor(member => member.Price);
    }
}
