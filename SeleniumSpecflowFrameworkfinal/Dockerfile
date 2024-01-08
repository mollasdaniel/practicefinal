# Use .NET Core SDK as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Set the working directory
WORKDIR /app

# Copy project files
COPY . .

# Restore dependencies
RUN dotnet restore "SeleniumSpecflowFrameworkfinal.csproj"

COPY . .
# WORKDIR "/src/SeleniumSpecflowFrameworkfinal"
RUN dotnet build "SeleniumSpecflowFrameworkfinal.csproj" 

#FROM build AS publish
# WORKDIR "/src/SeleniumSpecflowFrameworkfinal"
# RUN dotnet publish "SeleniumSpecflowFrameworkfinal.csproj" 

#FROM base AS final

# WORKDIR /app/bin/Debug/net6.0/
COPY . .
CMD ["dotnet", "test", "SeleniumSpecflowFrameworkfinal.dll"]
