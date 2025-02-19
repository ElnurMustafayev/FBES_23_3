namespace ValidationApp.Controllers;

using System.Text.Json;
using FluentValidation;
using FluentValidationApp.Models;
using Microsoft.AspNetCore.Mvc;
using ValidationApp.Models;

public class UserController : Controller
{
    private readonly IValidator<User> userValidator;
    public UserController(IValidator<User> userValidator)
    {
        this.userValidator = userValidator;
    }

    [HttpGet]
    public ActionResult Index() {
        return base.View();
    }

    [HttpGet]
    public ActionResult Create() {
        if(base.TempData.TryGetValue("validation_errors", out object? validationErrorsObject)) {
            if(validationErrorsObject is string validationErrorsJson) {
                var validationErrors = JsonSerializer.Deserialize<IEnumerable<ValidationErrorItem>>(validationErrorsJson);

                base.ViewData["validation_errors"] = validationErrors;
            }
        }

        return base.View();
    }

    [HttpPost("/[controller]")]
    [ActionName("CreateNewUser")]
    public async Task<ActionResult> Create([FromForm]User user) {
        var validationResult = await this.userValidator.ValidateAsync(user);

        if(validationResult.IsValid == false) {
            base.TempData["validation_errors"] = JsonSerializer.Serialize(validationResult.Errors.Select(error => {
                return new ValidationErrorItem {
                    Message = error.ErrorMessage,
                    Property = error.PropertyName
                };
            }));

            return base.RedirectToAction(nameof(Create), "User");
        }

        return base.RedirectToAction(nameof(Index), "User");
    }
}