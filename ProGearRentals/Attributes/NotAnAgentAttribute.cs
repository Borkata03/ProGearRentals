using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProGearRentals.Core.Contracts;
using System.Security.Claims;

namespace ProGearRentals.Attributes
{
    public class NotAnAgentAttribute : ActionFilterAttribute    
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
                    && agentservice.ExistByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

        }


    }
}
