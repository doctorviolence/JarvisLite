FROM microsoft/dotnet:sdk AS build-env
WORKDIR /jarvis-lite.server

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /jarvis-lite.server
COPY --from=build-env /jarvis-lite.server/out .
ENTRYPOINT ["dotnet", "jarvis-lite.server.dll"]