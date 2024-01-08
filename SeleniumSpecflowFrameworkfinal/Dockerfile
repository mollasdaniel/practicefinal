FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

# Use .NET Core SDK as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Set the working directory
WORKDIR /src

# Copy project files
COPY ["SeleniumSpecflowFrameworkfinal/SeleniumSpecflowFrameworkfinal.csproj", "SeleniumSpecflowFrameworkfinal/"]

# Restore dependencies
RUN dotnet restore "SeleniumSpecflowFrameworkfinal.csproj"

COPY . .
WORKDIR "/src/SeleniumSpecflowFrameworkfinal"
RUN dotnet build "SeleniumSpecflowFrameworkfinal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeleniumSpecflowFrameworkfinal.csproj" -c Release -o /app/publish

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "--settings ", "AutomatedTestQA.runsettings", "--filter" "SeleniumSpecflowFrameworkfinal.dll"]
