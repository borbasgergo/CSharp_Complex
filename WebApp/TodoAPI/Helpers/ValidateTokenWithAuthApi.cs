using System.Net.Http.Headers;

namespace WebApp.TodoAPI.Helpers;

public record JWT(bool isValid);
public static class ValidateTokenWithAuthApi
{
    public static async Task<bool> ValidateJwtToken(HttpContext context)
    {
        var token = context.Request.Headers["jwt"].ToString().Split()[1];
        
        var uri = new Uri("http://localhost:5072/api/auth/v1");
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Jwt", token);
        var responseMessage = await client.GetAsync(uri);
        
        var responseBody = await responseMessage.Content.ReadFromJsonAsync<JWT>();

        if (responseBody is not null)
        {
            if (responseBody.isValid)
            {
                return true;
            }
        }

        return false;
    }
}
