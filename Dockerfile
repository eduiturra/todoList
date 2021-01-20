FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY TodoList.Api/*.csproj ./TodoList.Api/
COPY TodoList.BLL/*.csproj ./TodoList.BLL/
COPY TodoList.Test/*.csproj ./TodoList.Test/ 
COPY TodoList.DAL/*.csproj ./TodoList.DAL/ 

#
RUN dotnet restore 
#
# copy everything else and build app
COPY TodoList.Api/. ./TodoList.Api/
COPY TodoList.BLL/. ./TodoList.BLL/
COPY TodoList.DAL/. ./TodoList.DAL/
COPY TodoList.Test/. ./TodoList.Test/

#
WORKDIR /app
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 
EXPOSE 80
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "TodoList.Api.dll"]