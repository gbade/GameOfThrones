# Game Of Thrones API

This project is a .NET 7.0 API for the Game of Thrones universe. It uses PostgreSQL for the database and Elasticsearch for logging. Kibana is used for visualizing the logs.


## Project Structure

    .db/
	    data/
	    init/ 
    .dockerignore 
    .gitattributes 
    .gitignore 
    .vs/
	    GameOfThrones/
	    ProjectEvaluation/ 
    docker-compose.yml 
    GameOfThrones.API/
	    appsettings.Development.json
	    appsettings.json
	    bin/
	    Controllers/
	    Dockerfile
	    Dockerfile.migration
	    GameOfThrones.API.csproj
	    GameOfThrones.API.csproj.user
	    obj/
	    Program.cs
	    Properties/
	    Startup.cs 
	GameOfThrones.Application/
	    bin/
	    ... 
	GameOfThrones.Domain/
	    bin/
	    Entities/
	    ... 
	GameOfThrones.Infrastructure/ 
	GameOfThrones.sln 
	GameOfThrones.Tests/ 
	README.md

## Configuration

### Environment Variables

The following environment variables are used in the project:

-   `ASPNETCORE_ENVIRONMENT`: Specifies the environment (e.g., Development, Production).
-   `Elasticsearch__Uri`: URI for the Elasticsearch instance.
-   `ConnectionStrings__DefaultConnection`: Connection string for the PostgreSQL database.

## Docker Compose

The  `docker-compose.yml`  file defines the services required for the project:

-   **Elasticsearch**: For logging.
-   **Kibana**: For visualizing logs.
-   **PostgreSQL**: For the database.
-   **Game of Thrones API**: The main API service.

### Dockerfile
The  `GameOfThrones.API/Dockerfile`  is used to build the API service.

## Running the Project

### Prerequisites
-   Docker
-   Docker Compose

### Steps
1.  **Clone the repository**:
    git clone `https://github.com/gbade/GameOfThrones.git` 
    cd  `{repository-directory}`
    
2.  **Build and run the services**: `docker-compose up  --build`
    
3.  **Access the services**:    
    -   **API**:  `http://localhost:5100`
    -   **Elasticsearch**:  `http://localhost:9200`
    -   **Kibana**:  `http://localhost:5601`

## Swagger

The API Swagger Doc can be accessed at `http:/localhost:5100/swagger`

