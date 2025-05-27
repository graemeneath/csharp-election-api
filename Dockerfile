FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
RUN apt-get update && apt-get install -y curl  # Only for debugging

EXPOSE 8080

COPY ./publish ./
ENTRYPOINT ["dotnet", "election-api.dll"]
