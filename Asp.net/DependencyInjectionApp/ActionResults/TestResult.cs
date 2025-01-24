namespace DependencyInjectionApp.ActionResults;

using Microsoft.AspNetCore.Mvc;

public class TestResult : ActionResult {
    public override void ExecuteResult(ActionContext context)
    {
        context.HttpContext.Response.StatusCode = 777;
        base.ExecuteResult(context);
    }
}