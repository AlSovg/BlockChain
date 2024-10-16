using System.Text;
using System.Text.Json;
using BlockChain.Models;
using BlockChain.Models.Base;

namespace BlockChain.Repository;

public class TaskRepository 
{
    private readonly string baseUrl = "https://b1.ahmetshin.com/restapi/";
    private readonly HttpClient _httpClient;
    
    public TaskRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("mode", "no-cors");
    }
    
    public async Task<SuccessMessageModel?> SendCoins(string? jsonData)
    {
        var url = $"{baseUrl}send_task";
        using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response =  await _httpClient.PostAsync(url, content);
        var responseStream = await response.Content.ReadAsStreamAsync();
        var responseString = await response.Content.ReadAsStringAsync();
        var responseContent = await JsonSerializer.DeserializeAsync<SuccessMessageModel>(responseStream);
        return responseContent;
    }
    
}