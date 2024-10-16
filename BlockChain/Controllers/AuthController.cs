using System.Text.Json;
using BlockChain.Models;
using BlockChain.Models.Base;
using BlockChain.Repository;
using BlockChain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Controllers;

[Route("Auth")]
public class AuthController : Controller
{
    private readonly ILogger<BlockController> logger;
    private readonly AuthRepository authRepository;

    public AuthController(ILogger<BlockController> logger, AuthRepository authRepository)
    {
        this.logger = logger;
        this.authRepository = authRepository;
    }
    
    
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
    

    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromForm] AuthData userData)
    {
        var isFileRewrote = PythonActions.ReplaceUserData("./Python/start.py", userData);
        if (!isFileRewrote) return Ok();
        var userInfo = await PythonActions.ExecutePythonScriptAsync();
        userInfo!.username = userData.username;
        userInfo.password = userData.password;
        var userInfo1 = new UserData1()
        {
            username = userInfo.username,
            password = userInfo.password,
            hach_version_file = userInfo.hach_version_file,
            user_hash = userInfo.user_hash
        };
        
        HttpContext.Session.SetString("userInfo", JsonSerializer.Serialize(userInfo1));
        return Json(new SuccessMessageModel()
        {
            Message = "Авторизация успешна!"
        });
    }

    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromForm] AuthData userData)
    {
        var isFileRewrote = PythonActions.ReplaceUserData("./Python/start.py", userData);
        if (!isFileRewrote) return Ok();
        var userInfo = await PythonActions.ExecutePythonScriptAsync();
        var userInfo1 = new UserData1()
        {
            username =  userData.username,
            password = userData.password,
            hach_version_file = userInfo.hach_version_file,
            user_hash = userInfo.user_hash
        };
        HttpContext.Session.SetString("userInfo", JsonSerializer.Serialize(userInfo1));
        var json = HttpContext.Session.GetString("userInfo") == null ? "" : HttpContext.Session.GetString("userInfo")?.ToString();
        var response = await authRepository.Register(json);
        if (response!.Success)
        {
            return Json(new SuccessMessageModel()
            {
                Message = "Успешно зарегистрированы!"
            });
        }
        
        logger.LogError("Register failed");
        return BadRequest(response);
    }
    

    [Route("Logout")]
    public Task Logout()
    {
        HttpContext.Session.Remove("userInfo");
        return Task.CompletedTask;
    }
}