using System.Text;
using System.Text.Json;
using BlockChain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TaskChain.Controllers;

[Route("User")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly UserRepository _userRepository;

    public UserController(ILogger<UserController> logger, UserRepository userRepository)
    {
        this._logger = logger;
        this._userRepository = userRepository;
    }
    
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("getUsers")]
    [HttpGet]
    public async  Task<IActionResult> GetUsers()
    {
        var json = HttpContext.Session.GetString("userInfo") == null ? "" : HttpContext.Session.GetString("userInfo")?.ToString();
        var response = await _userRepository.GetUsers(json!);
        var users = response;
        if (response is not null)
        {
            return PartialView(users);
        }
        _logger.LogError("Get last blocks failed");
        return BadRequest(response);
    }
}