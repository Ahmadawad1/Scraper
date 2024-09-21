# Web Scraper Project

## Overview

This project is a web scraper that processes a list of URLs and retrieves the `title` from HTML or JSON files. It supports scraping HTML pages and JSON data, extracting the title value based on the file type.

## Features

- **HTML Scraping**: Retrieves the `<h1>` header inner value from HTML files.
- **JSON Parsing**: Extracts the `"title"` property from JSON files.
- **Supports Multiple File Types**: Can easily be extended to handle more file formats in the future.
- **Error Handling**: Safeguards against invalid URLs and unexpected file formats.

## Project Structure

- **Controllers**: Contains the API controllers for handling HTTP requests.
- **Services**: The business logic for scraping content from URLs.
- **Utils**: Utility functions, such as methods to handle URLs, file types, and content extraction.
- **Repository**: Since there's no data storage needed for this task, data llayer will be empty an open for extension.

## Prerequisites

- **.NET Core SDK 5.0 or higher**
- **Visual Studio or VS Code**

## Usage

### 1. Scraping URLs

You can send a list of URLs to the API, and it will return the scraped `title` for each file.

**Example API Request:**
```bash
curl -X POST https://localhost:44317/scrapper -H "Content-Type: application/json" -d '["http://example.com/page.html", "http://example.com/data.json"]'
