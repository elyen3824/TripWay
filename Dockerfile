
FROM microsoft/aspnetcore
LABEL Name=tripwaycsharp Version=0.0.1 
ARG source=./VisitPath/obj/Docker/publish
WORKDIR /app
COPY $source .
ENTRYPOINT dotnet VisitPath.dll
