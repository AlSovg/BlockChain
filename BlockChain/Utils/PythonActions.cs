using BlockChain.Models;
using System.Diagnostics;
using System.Text.Json;
namespace BlockChain.Utils;

public class PythonActions
{
    public static bool ReplaceUserData(string filename, AuthData newUserData)
    {
        try
        {
            string fileContent = File.ReadAllText(filename);
            fileContent = fileContent.Replace(
                fileContent.Split('\n').FirstOrDefault(line => line.Contains("username =")),
                $"username = '{newUserData.username}'"
            );

            fileContent = fileContent.Replace(
                fileContent.Split('\n').FirstOrDefault(line => line.Contains("password =")),
                $"password = '{newUserData.password}'"
            );
            File.WriteAllText(filename, fileContent);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении/записи файла: {ex.Message}");
        }

        return false;
    }
    public static async Task<UserData?> ExecutePythonScriptAsync()
    {
        try
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = "./Python/start.py",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();

            string stdout = await process.StandardOutput.ReadToEndAsync();
            stdout = stdout.Replace("'", "\"");
            var result = JsonSerializer.Deserialize<UserData>(stdout);
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}