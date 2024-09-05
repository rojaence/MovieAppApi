# MOVIE APP API

## Overview

This api serves as an intermediary to consume an external API, providing data through different endpoints.

Developed in a Linux environment with a DevContainer in VSCode using .NET and C#

## Requirements

* .NET 8 SDK
* Newtonsoft.Json
* RestSharp
* Moq (testing)
* Xunit (testing)

## Installation

1. Clone the repository

```bash
   git clone https://github.com/rojaence/MovieAppApi.git
```

2. Navigate to project folder

   ```bash
   cd src
   ```
3. Restore the dependencies

```bash
   dotnet restore
```

4. Configure .env
   In project folder "src" create a .env file with the next variables:

   BASE_URL=https://api.themoviedb.org/3

   CLIENT_URL=your_client_app_url

   API_KEY=your_TMDB_api_key

## Run

From terminal:

```bash
dotnet run
```

or

```bash
dotnet watch run
```

## Endpoints

**Note:** Use swagger UI to preview all endpoints and options; you can omit '/api'

### movies / tv (replace 'resource')

    /api/resource

    /api/resource/trending

    /api/resource/popular

    /api/resource/{id}/recommendations

    /api/resource/{id}/images

    /api/resource/{id}/videos

    /api/resource/search

    /api/resource/genres

### person

    /api/person/{id}

    /api/person/trending

    /api/person/popular

    /api/person/search

    /api/person/{id}/credits/movie

    /api/person/{id}/credits/tv
