# Use the official .NET 6.0 SDK as the build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# Set the working directory to /app
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build the application
RUN dotnet build 

# Use the official .NET 6.0 runtime as the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory to /app
WORKDIR /app

# Copy the built artifacts from the build image
COPY --from=build . .

# Set up environment variables for running Selenium in headless mode
# ENV ASPNETCORE_URLS=http://+:5000
# ENV ASPNETCORE_ENVIRONMENT=Production
# ENV ASPNETCORE_HEADLESS=true

# Run the tests when the container launches
CMD ["dotnet", "SeleniumSpecflowFrameworkfinal"]
#ENTRYPOINT ["dotnet", "SeleniumSpecflowFrameworkfinal.dll"]
