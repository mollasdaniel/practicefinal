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

FROM ubuntu:22.04

RUN apt-get update; apt-get clean

# Install wget.
RUN apt-get install -y wget

RUN apt-get install -y gnupg

# Set the Chrome repo.
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && echo "deb http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list

# Install Chrome.
RUN apt-get update && apt-get -y install google-chrome-stable
# Check chrome version
RUN echo "Chrome: " && google-chrome --version


# Use the official .NET runtime as the runtime image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS runtime

# Set the working directory to /app
WORKDIR /app

# Copy the built artifacts from the build image
COPY --from=build /app/out ./

RUN ls -l
# Run the tests when the container launches
RUN dotnet test SeleniumSpecflowFrameworkfinal.dll
# ENTRYPOINT ["dotnet", "test"]
