using System.Text;
using System.Text.Json;
using BlockChain.Models.Chains;

namespace BlockChain.Repository;

public class UserRepository 
{
    private readonly string baseUrl = "https://b1.ahmetshin.com/restapi/";
    private readonly HttpClient _httpClient;
    
    public UserRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("mode", "no-cors");
    }
    
    public async Task<List<User>?> GetUsers(string? jsonData)
    {
        var url = $"{baseUrl}get_chains";
        using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response =  await _httpClient.PostAsync(url, content);
        var responseStream = await response.Content.ReadAsStreamAsync();
        var responseContent = await JsonSerializer.DeserializeAsync<ServiceResponseModel>(responseStream);
        var users = responseContent?.ActiveBlock.Users;
        return users;
    }
    
}