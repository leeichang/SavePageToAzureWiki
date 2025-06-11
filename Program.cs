using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        //set the URL of the web page you want to fetch
        string url = "https://adminnet.top/backendbook/remoterequest.html";
        //set the page name of the wiki page you want to create or update
        string pagePath = "25. 遠端請求";
        string wikiContent = await GetWebContent(url);
        await UpdateWikiPage(wikiContent, pagePath);
    }

    static async Task<string> GetWebContent(string url)
    {
        try
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var doc = new HtmlDocument();
                doc.LoadHtml(response);

                // get <div class="theme-hope-content">  content inside <div class="theme-hope-content">
                var hintContent = doc.DocumentNode.SelectSingleNode("//div[@class='theme-hope-content']")?.InnerHtml;
                string content = hintContent ?? response; // 如果找不到則返回完整內容
                Console.WriteLine("成功獲取網頁內容");
                return content;
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"獲取網頁內容失敗: {ex.Message}");
            Console.WriteLine($"狀態碼: {(ex.StatusCode.HasValue ? ex.StatusCode.Value.ToString() : "無狀態碼")}");
            Console.WriteLine($"堆棧跟踪: {ex.StackTrace}");
            return string.Empty;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"獲取網頁內容異常: {ex.Message}");
            Console.WriteLine($"堆棧跟踪: {ex.StackTrace}");
            return string.Empty;
        }
    }
    static async Task UpdateWikiPage(string content,string pagePath)
    {
        try
        {
            if (string.IsNullOrEmpty(content))
            {
                Console.WriteLine("內容為空，無法更新 Wiki 頁面");
                return;
            }

            string pat = "get your own Personal Access Tokens";
            string organization = "cym-dpa"; // 請替換為你的組織名稱
            string project = "CymChain";    // 請替換為你的項目名稱
            //GET https://dev.azure.com/{organization}/_apis/projects?api-version=5.0  //get your project ID
            //GET https://dev.azure.com/{organization}/{project}/_apis/wiki/wikis?api-version=7.1 // get your wiki ID
            string wikiIdentifier = "900b3b2a-ee48-4797-9c5b-dac14fe313eb"; // 請替換為你的 Wiki ID 或名稱
        

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($":{pat}")));

                string apiUrl = $"https://dev.azure.com/{organization}/{project}/_apis/wiki/wikis/{wikiIdentifier}/pages?path={Uri.EscapeDataString(pagePath)}&api-version=7.1";
                
                var updateData = new { content = content };
                var updateJson = JsonConvert.SerializeObject(updateData);
                var updateContent = new StringContent(updateJson, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync(apiUrl, updateContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Wiki 頁面更新成功，狀態碼: {response.StatusCode}");
                    string eTag = response.Headers.GetValues("ETag").FirstOrDefault();
                    Console.WriteLine($"ETag: {eTag}");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"更新 Wiki 頁面失敗，狀態碼: {response.StatusCode}");
                    Console.WriteLine($"錯誤詳情: {error}");
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"更新 Wiki 頁面失敗 (HTTP 錯誤): {ex.Message}");
            Console.WriteLine($"狀態碼: {(ex.StatusCode.HasValue ? ex.StatusCode.Value.ToString() : "無狀態碼")}");
            Console.WriteLine($"堆棧跟踪: {ex.StackTrace}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON 序列化異常: {ex.Message}");
            Console.WriteLine($"堆棧跟踪: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"更新 Wiki 頁面異常: {ex.Message}");
            Console.WriteLine($"堆棧跟踪: {ex.StackTrace}");
        }
    }
}