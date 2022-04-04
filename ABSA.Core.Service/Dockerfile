#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ABSA.Core.Service/ABSA.Core.Service.csproj", "PhoneBook/"]
RUN dotnet restore "ABSA.Core.Service/ABSA.Core.Service.csproj"
COPY . .
WORKDIR "/src/ABSA.Core.Service.csproj"
RUN dotnet build "ABSA.Core.Service.csproj.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ABSA.Core.Service.csproj.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ABSA.Core.Service.dll"]