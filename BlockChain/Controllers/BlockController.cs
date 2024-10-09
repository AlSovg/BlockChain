using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Controllers;

[Route("Blocks")]
public class BlockController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}