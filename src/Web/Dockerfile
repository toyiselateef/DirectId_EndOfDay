#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Web/DirectId_EOD.csproj", "src/Web/"]
COPY ["src/Infrastructure/Shared/Shared.csproj", "src/Infrastructure/Shared/"]
COPY ["src/Core/Application/Application.csproj", "src/Core/Application/"]
COPY ["src/Core/Domain/Domain.csproj", "src/Core/Domain/"]
COPY ["src/Infrastructure/Implementation/Implementation.csproj", "src/Infrastructure/Implementation/"]
COPY ["src/Infrastructure/Persistance/Persistance.csproj", "src/Infrastructure/Persistance/"]
RUN dotnet restore "src/Web/DirectId_EOD.csproj"
COPY . .
WORKDIR "/src/src/Web"
RUN dotnet build "DirectId_EOD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DirectId_EOD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DirectId_EOD.dll"]