using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HomeBillings.Identidade.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Errors = [];

        protected ActionResult CustomResponse(object? result = null)
        {
            if (ActionIsValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(x => x.Errors);
            foreach (var error in errors)
            {
                AddNotificationError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool ActionIsValid()
            => !Errors.Any();

        protected void AddNotificationError(string erro)
        {
            Errors.Add(erro);
        }

        protected void ClearNotificationErrors(string erro)
        {
            Errors.Clear();
        }
    }
}
