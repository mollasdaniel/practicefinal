# Use the official .NET SDK as the build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory to /app
WORKDIR /app

# Copy the project file and restore dependencies
COPY ./*.csproj ./
RUN dotnet restore

# Copy the remaining source code
COPY ./ ./

# Build the application
RUN dotnet build -c Release -o out

# Use the official .NET runtime as the runtime image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS runtime

# Set the working directory to /app
WORKDIR /app

# Copy the built artifacts from the build image
COPY --from=build /app/out ./

# Install Chrome and Chromedriver
RUN apt-get update && \
    apt-get install -y chromium

RUN ls -l
# Run the tests when the container launches
RUN dotnet test SeleniumSpecflowFrameworkfinal.dll
#CMD ["dotnet", "SeleniumSpecflowFrameworkfinal.csproj"]
