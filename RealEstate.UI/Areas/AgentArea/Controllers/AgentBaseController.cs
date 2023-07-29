using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace RealEstate.UI.Areas.AgentArea.Controllers
{
    [Area("AgentArea")]
    //[Authorize(Roles = "Agent")]
    public class AgentBaseController : Controller
    {
       
    }
}
