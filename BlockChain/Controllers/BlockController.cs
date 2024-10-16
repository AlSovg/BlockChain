using System.Text;
using System.Text.Json;
using BlockChain.Models;
using BlockChain.Models.Chains;
using BlockChain.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Controllers;

[Route("Block")]
public class BlockController : Controller
{
    private readonly ILogger<BlockController> logger;
    private readonly BlockRepository blockRepository;

    public BlockController(ILogger<BlockController> logger, BlockRepository blockRepository)
    {
        this.logger = logger;
        this.blockRepository = blockRepository;
    }
    
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
    

    [Route("getCoins")]
    [HttpGet]
    public async Task<IActionResult> GetCoins()
    {
        var authData = HttpContext.Session.GetString("userInfo");
        var response = await blockRepository.GetCoins(authData);
        return PartialView(response);
    }

    [Route("getLastBlock")]
    [HttpGet]
    public async Task<IActionResult> GetLastBlock()
    {
        var json = HttpContext.Session.GetString("userInfo") == null ? "" : HttpContext.Session.GetString("userInfo")?.ToString();
        var response = await blockRepository.GetBlocksAsync(json!);
        var lastBlock = response?[1];
        if (response is not null)
        {
            return PartialView(lastBlock);
        }
        logger.LogError("Get last blocks failed");
        return BadRequest(response);
    }
}