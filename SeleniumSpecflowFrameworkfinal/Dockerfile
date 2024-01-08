# Use .NET Core SDK as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Set the working directory
WORKDIR /app

# Copy project files
COPY . .

# Restore dependencies
RUN dotnet restore "SeleniumSpecflowFrameworkfinal.csproj"

COPY . .
RUN dotnet build "SeleniumSpecflowFrameworkfinal.csproj"

FROM build AS publish
RUN dotnet publish "SeleniumSpecflowFrameworkfinal.csproj" 

FROM base AS final

COPY . .
ENTRYPOINT ["dotnet", "--settings ", "AutomatedTestQA.runsettings", "--filter" "SeleniumSpecflowFrameworkfinal.dll"]
