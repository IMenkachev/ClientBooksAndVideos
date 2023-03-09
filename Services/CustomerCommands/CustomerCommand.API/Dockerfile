#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/CustomerCommands/CustomerCommand.API/CustomerCommand.API.csproj", "Services/CustomerCommands/CustomerCommand.API/"]
COPY ["Services/CustomerCommands/CustomerCommands.Application/CustomerCommands.Application.csproj", "Services/CustomerCommands/CustomerCommands.Application/"]
COPY ["Services/CustomerCommands/CustomerCommands.Domain/CustomerCommands.Domain.csproj", "Services/CustomerCommands/CustomerCommands.Domain/"]
COPY ["Services/CustomerCommands/CustomerCommands.Infrastructure/CustomerCommands.Infrastructure.csproj", "Services/CustomerCommands/CustomerCommands.Infrastructure/"]
RUN dotnet restore "Services/CustomerCommands/CustomerCommand.API/CustomerCommand.API.csproj"
COPY . .
WORKDIR "/src/Services/CustomerCommands/CustomerCommand.API"
RUN dotnet build "CustomerCommand.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerCommand.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerCommand.API.dll"]