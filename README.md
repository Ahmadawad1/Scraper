# Web Scraper Project

## Overview

This project is a web scraper that processes a list of URLs and retrieves the `title` from HTML or JSON files. It supports scraping HTML pages and JSON data, extracting the title value based on the file type.

## Functional Features

- **HTML Scraping**: Retrieves the `<h1>` header inner value from HTML files.
- **JSON Parsing**: Extracts the `"title"` property from JSON files.
- **Supports Multiple File Types**: Can easily be extended to handle more file formats in the future.
- **Error Handling**: Safeguards against invalid URLs and unexpected file formats.

## Technical Features
- **Architecture Pattern**: The project follows a layered architecture where responsibilities are divided into distinct layers, such as controllers, services, and utilities.
- **Abstraction/Separation of Concern**: Each layer is exposed as an interface, allowing for a clean separation of concerns and easier maintainability.
- **Extensibility**: The design allows for the future addition of more file types or URL structures.
- **Testability**: The project includes unit tests and integrates CI pipelines via GitHub Actions for continuous testing and validation.
- **Throttling/Rate Limiting**: A semaphone object was used to handle only 10 concurrent urls at same time
- **Performance**: Async/Prallel programming was considered in all methods

## Clean Code
### SOLID Principles 
**SRP**: Each functionality is separated in a separate method.
**OCP**: The feature is designed to be opened for future extension
**DIP**: As the service is exposed as interface, all details are hidden, and any change on the details, the contract (interface) will remain with no change.

### DRY, KISS, YAGNI, Naming Convenstion
The code lines were also written in respect to those principles.

## Project Structure

- **Controllers**: Contains the API controllers for handling HTTP requests.
- **Services**: The business logic for scraping content from URLs.
- **Utils**: Utility functions, such as methods to handle URLs, file types, and content extraction.
- **Repository**: Since there's no data storage needed for this task, data llayer will be empty an open for extension.


## Prerequisites

- **.NET Core SDK 5.0 or higher**
- **Visual Studio or VS Code**

## CI 
Any push request will trigger the CI pipeline and the Test Action will show the unit test result (There's a **total of 12 test case**s for this project)

## Local Test

You can send a list of URLs to the API, and it will return the scraped `title` for each file.
Just clone the repo, build the .NET app locally and use Postman/Swagger/CURL to test the API.

**Example API Request:**
```bash
curl -X POST https://localhost:44317/scrapper -H "Content-Type: application/json" -d '["http://example.com/page.html", "http://example.com/data.json"]'

P.S.
In our case, since the mock server stores test files locally, the base URL (http://example.com) is irrelevant—the API is mainly concerned with the filename. But yes, the full URL still needs to be passed along.
