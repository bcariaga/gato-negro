FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim
WORKDIR /app

COPY /src/Api/bin/Release/net5.0/publish /app

ENV ASPNETCORE_URLS=http://+80

EXPOSE 80

ENTRYPOINT ["dotnet", "Api.dll"]