using System.Text.Json;
using BlockChain.Models;
using BlockChain.Models.Base;
using BlockChain.Models.Tasks;
using BlockChain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Controllers;

[Route("Task")]
public class TaskController : Controller
{
    private readonly ILogger<TaskController> _logger;
    private readonly TaskRepository _taskRepository;

    public TaskController(ILogger<TaskController> logger, TaskRepository taskRepository)
    {
        this._logger = logger;
        this._taskRepository = taskRepository;
    }
    
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("sendCoins")]
    [HttpPost]
    public async Task<IActionResult> SendCoins(SendCoinsTask task)
    {
        var model = JsonSerializer.Deserialize<UserData1>(HttpContext.Session.GetString("userInfo"));
        model.data = (task);
        var json = JsonSerializer.Serialize(model);
        var response = await _taskRepository.SendCoins(json!);
        if (response!.Success)
        {
            return Json(new SuccessMessageModel()
            {
                Message = "Задача создана успешна!"
            });
        }
        _logger.LogError("Get last blocks failed");
        return BadRequest(response);
    }
}