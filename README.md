以下是為你的 GitHub 專案準備的 `README.md` 內容，包含中英文版本。內容涵蓋專案概述、安裝說明、使用方法、貢獻指南和授權資訊，適合提交到 GitHub。

```markdown
# Web Content to Azure DevOps Wiki Tool

## Overview (概述)
This is a C# console application designed to fetch content from a specified web page and update or create a page in an Azure DevOps Wiki. The tool uses the Azure DevOps REST API to manage wiki pages and HtmlAgilityPack to parse HTML content. It is particularly useful for automating the process of documenting web-based content in Azure DevOps.

這是一個 C# 控制台應用程序，用於從指定網頁獲取內容並更新或創建 Azure DevOps Wiki 頁面。該工具使用 Azure DevOps REST API 管理 Wiki 頁面，並使用 HtmlAgilityPack 解析 HTML 內容。特別適用於自動化在 Azure DevOps 中記錄基於網頁的內容。

## Features (功能)
- Fetch HTML content from a public web URL.
- Extract specific content (e.g., `<div class="theme-hope-content">`) using HtmlAgilityPack.
- Update or create a wiki page in Azure DevOps using the REST API.
- Handle errors with detailed logging for debugging.

- 從公共網址獲取 HTML 內容。
- 使用 HtmlAgilityPack 提取特定內容（例如 `<div class="theme-hope-content">`）。
- 使用 REST API 在 Azure DevOps 中更新或創建 Wiki 頁面。
- 提供詳細日誌以便於除錯。

## Prerequisites (先決條件)
- **.NET SDK**: Version 6.0 or later.
- **NuGet Packages**:
  - `HtmlAgilityPack`
  - `Newtonsoft.Json`
- **Azure DevOps Personal Access Token (PAT)**: With `vso.wiki_write` scope.
- **Internet Connection**: To access the web page and Azure DevOps API.

- **.NET SDK**: 6.0 或更高版本。
- **NuGet 套件**：
  - `HtmlAgilityPack`
  - `Newtonsoft.Json`
- **Azure DevOps 個人訪問令牌 (PAT)**: 包含 `vso.wiki_write` 範圍。
- **網絡連接**: 用於訪問網頁和 Azure DevOps API。

## Installation (安裝)
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/your-repo-name.git
   ```
2. Navigate to the project directory:
   ```bash
   cd your-repo-name
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Build the project:
   ```bash
   dotnet build
   ```

1. 克隆倉庫：
   ```bash
   git clone https://github.com/yourusername/your-repo-name.git
   ```
2. 進入項目目錄：
   ```bash
   cd your-repo-name
   ```
3. 恢復依賴項：
   ```bash
   dotnet restore
   ```
4. 構建項目：
   ```bash
   dotnet build
   ```

## Usage (使用方法)
1. Update the `Main` method with your target URL and page path:
   - `string url = "https://adminnet.top/backendbook/remoterequest.html";`
   - `string pagePath = "25. 遠端請求";`
2. Replace the `pat`, `organization`, `project`, and `wikiIdentifier` in the `UpdateWikiPage` method with your Azure DevOps credentials:
   - Example: `string pat = "your_pat_here";`
   - Get `wikiIdentifier` via: `GET https://dev.azure.com/{organization}/{project}/_apis/wiki/wikis?api-version=7.1`
3. Run the application:
   ```bash
   dotnet run
   ```
4. Check the console output for success messages or error details.

1. 在 `Main` 方法中更新目標 URL 和頁面路徑：
   - `string url = "https://adminnet.top/backendbook/remoterequest.html";`
   - `string pagePath = "25. 遠端請求";`
2. 在 `UpdateWikiPage` 方法中替換 `pat`、`organization`、`project` 和 `wikiIdentifier` 為你的 Azure DevOps 憑據：
   - 例如：`string pat = "your_pat_here";`
   - 通過以下方式獲取 `wikiIdentifier`：`GET https://dev.azure.com/{organization}/{project}/_apis/wiki/wikis?api-version=7.1`
3. 運行應用程序：
   ```bash
   dotnet run
   ```
4. 檢查控制台輸出，查看成功訊息或錯誤詳情。

## Contributing (貢獻指南)
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch: `git checkout -b feature-branch`.
3. Make your changes and commit: `git commit -m "Add new feature"`.
4. Push to the branch: `git push origin feature-branch`.
5. Submit a pull request.

歡迎貢獻！請遵循以下步驟：
1. 叉取倉庫。
2. 創建新分支：`git checkout -b feature-branch`。
3. 進行更改並提交：`git commit -m "添加新功能"`。
4. 推送分支：`git push origin feature-branch`。
5. 提交拉取請求。

## License (授權)
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

此項目採用 MIT 許可證授權。詳情請參見 [LICENSE](LICENSE) 文件。

## Acknowledgments (鳴謝)
- Thanks to the HtmlAgilityPack and Newtonsoft.Json communities for their excellent libraries.
- Inspired by the need to automate documentation in Azure DevOps.

- 感謝 HtmlAgilityPack 和 Newtonsoft.Json 社區提供的出色庫。
- 靈感來自於我要製作團隊的學習文件放在公司內部！，但是我使用的框架是一個外部的框架，他有說明文件！。
```
