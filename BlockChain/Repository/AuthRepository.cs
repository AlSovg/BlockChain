using System.Text;
using System.Text.Json;
using BlockChain.Models;
using BlockChain.Models.Base;

namespace BlockChain.Repository;

public class AuthRepository 
{
    private readonly string _baseUrl = "https://b1.ahmetshin.com/restapi/";
    private readonly HttpClient _httpClient;
    
    public AuthRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("mode", "no-cors");
    }
    
    public async Task<MessageModel?> Register(string? jsonData)
    {
        var url = $"{_baseUrl}register";
        using var content = new StringContent(jsonData!, Encoding.UTF8, "application/json");
        var response =  await _httpClient.PostAsync(url, content);
        var responseStream = await response.Content.ReadAsStreamAsync();
        var responseContent = await JsonSerializer.DeserializeAsync<MessageModel>(responseStream);
        return responseContent;
    }
}