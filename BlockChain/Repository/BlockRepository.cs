using System.Text;
using System.Text.Json;
using BlockChain.Models;
using BlockChain.Models.Chains;

namespace BlockChain.Repository;

public class BlockRepository 
{
    private readonly string baseUrl = "https://b1.ahmetshin.com/restapi/";
    private readonly HttpClient _httpClient;
    
    public BlockRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("mode", "no-cors");
    }
    
    public async Task<CoinsCountModel?> GetCoins(string? jsonData)
    {
        var url = $"{baseUrl}check_coins";
        using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response =  await _httpClient.PostAsync(url, content);
        var responseStream = await response.Content.ReadAsStreamAsync();
        var responseContent = await JsonSerializer.DeserializeAsync<CoinsCountModel>(responseStream);
        return responseContent;
    }

    public async Task<List<Block>?> GetBlocksAsync(string jsonData)
    {
        var url = $"{baseUrl}get_chains";
        using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response =  await _httpClient.PostAsync(url, content);
        var responseStream = await response.Content.ReadAsStreamAsync();
        var responseContent = await JsonSerializer.DeserializeAsync<ServiceResponseModel>(responseStream);
        var blocks = responseContent?.ActiveBlock.Blocks;
        return blocks;
    }
}