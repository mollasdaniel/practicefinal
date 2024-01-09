# Use the official .NET 6.0 SDK as the build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory to /app
WORKDIR /app

# Copy the project file and restore dependencies
COPY . .
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Set the working directory to /app
WORKDIR /app

# Copy the built artifacts from the build image
COPY . . 

# Run the tests when the container launches
CMD ["dotnet","SeleniumSpecflowFrameworkfinal.dll"]
#ENTRYPOINT ["dotnet", "SeleniumSpecflowFrameworkfinal.dll"]
