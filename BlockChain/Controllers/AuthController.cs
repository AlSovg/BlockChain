using System.Text.Json;
using BlockChain.Models;
using BlockChain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Controllers;

[Route("Login")]
public class AuthController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("Try")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] AuthData userData)
    {
        var isFileRewrote = PythonActions.ReplaceUserData("./Python/start.py", userData);
        if (!isFileRewrote) return Ok();
        var userInfo = await PythonActions.ExecutePythonScriptAsync();
        userInfo!.UserName = userData.UserName;
        userInfo.Password = userData.Password;
        HttpContext.Session.SetString("userInfo", JsonSerializer.Serialize(userInfo));
        return Ok();
    }
}