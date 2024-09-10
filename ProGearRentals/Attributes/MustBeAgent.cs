using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Core.Contracts;
using System.Security.Claims;
using ProGearRentals.Controllers;

namespace ProGearRentals.Attributes
{
    public class MustBeAgent : ActionFilterAttribute    
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            base.OnActionExecuted(context);

            IAgentService? agentservice = context.HttpContext.RequestServices.GetService<IAgentService>();

            if (agentservice == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (agentservice != null
                    && agentservice.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(AgentController.Become), "Agent", null);
            }

        }
    }
}
