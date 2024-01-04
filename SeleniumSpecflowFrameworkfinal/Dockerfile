# Use .NET Core SDK as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Set the working directory
WORKDIR /app

# Copy project files
COPY . .

# Restore dependencies
RUN dotnet restore

# Install SpecFlow and Selenium WebDriver
# RUN dotnet tool install --global SpecFlow.Tools.MsBuild.Generation
RUN dotnet add package Selenium.WebDriver

# Generate SpecFlow bindings
# RUN dotnet specflow generateall

# Run the SpecFlow tests
CMD ["dotnet", "test", "--filter", "SeleniumSpecflowFrameworkfinal.dll","--logger","trx"]
