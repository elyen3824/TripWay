
FROM microsoft/aspnetcore:1
LABEL Name=tripwaycsharp Version=0.0.1 
ARG source=.
WORKDIR /app
EXPOSE 80
COPY $source .
ENTRYPOINT dotnet tripwaycsharp.dll
