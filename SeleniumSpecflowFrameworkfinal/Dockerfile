FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore  
# Install SpecFlow and Selenium WebDriver
# RUN dotnet tool install --global SpecFlow.Tools.MsBuild.Generation
RUN dotnet add package Selenium.WebDriver

RUN dotnet build  -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeleniumSpecflowFrameworkfinal.dll"]
