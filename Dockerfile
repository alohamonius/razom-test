FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
  
WORKDIR /src
COPY . /src
RUN dotnet restore "RazomSoftware.csproj"
RUN dotnet build "RazomSoftware.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RazomSoftware.csproj" -c Release -o /app/publish

FROM node as node-builder
RUN apt-get update && apt-get install -y curl
RUN curl -sL https://deb.nodesource.com/setup_17.x | bash -
RUN apt-get update && apt-get install -y nodejs

WORKDIR ./node
COPY ./ClientApp /node
RUN npm install --loglevel=error
RUN npm run build


FROM build AS final
WORKDIR /app
RUN mkdir /app/wwwroot

COPY --from=publish /app/publish .
COPY --from=node-builder ./node/build ./wwwroot
ENTRYPOINT ["dotnet", "RazomSoftware.dll"]