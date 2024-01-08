# Use .NET Core SDK as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Set the working directory
WORKDIR /src

# Copy project files
COPY ["SeleniumSpecflowFrameworkfinal.csproj", "SeleniumSpecflowFrameworkfinal/"]

# Restore dependencies
RUN dotnet restore "SeleniumSpecflowFrameworkfinal.csproj"

COPY . .
WORKDIR "/src/SeleniumSpecflowFrameworkfinal"
RUN dotnet build "SeleniumSpecflowFrameworkfinal.csproj" -c Release -o /src/build

FROM build AS publish
RUN dotnet publish "SeleniumSpecflowFrameworkfinal.csproj" -c Release -o /src/publish

FROM base AS final

WORKDIR /src
COPY --from=publish /src/publish .
ENTRYPOINT ["dotnet", "--settings ", "AutomatedTestQA.runsettings", "--filter" "SeleniumSpecflowFrameworkfinal.dll"]
