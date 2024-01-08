# Use .NET Core SDK as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

COPY . .
RUN dotnet restore   
RUN dotnet build  -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeleniumSpecflowFrameworkfinal.dll"]
