using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Filters;

public class NotFoundFilter : ActionFilterAttribute
{
    private readonly ProjectContext _context;

    public NotFoundFilter(ProjectContext context)
    {
        _context = context;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var idValue = (int) context.ActionArguments.Values.First();

        var hasProduct = _context.Products.Any(x => x.Id == idValue);

        if (!hasProduct)
        {
            context.Result = new RedirectToActionResult("Error", "Home", new ErrorViewModel()
            {
                Errors = new List<string>{$"Product with the Id({idValue}) can not be found"}
            });
        }
    }
}