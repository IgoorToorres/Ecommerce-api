run:
	ASPNETCORE_ENVIRONMENT=Development dotnet run --project src/Ecommerce.Api/Ecommerce.Api.csproj

build:
	dotnet build src/Ecommerce.Api/Ecommerce.Api.csproj

test:
	dotnet test tests/Ecommerce.UnitTests/Ecommerce.UnitTests.csproj --no-restore

db-up:
	docker compose up -d

db-down:
	docker compose down
