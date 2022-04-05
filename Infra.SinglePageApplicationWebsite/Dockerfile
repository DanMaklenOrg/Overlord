FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app

COPY Infra.SinglePageApplicationWebsite.csproj .

RUN dotnet restore

COPY . .

RUN dotnet publish -o bin -c Release --no-restore

FROM mcr.microsoft.com/dotnet/sdk:6.0

RUN apt-get update --assume-yes
RUN apt-get install jq --assume-yes
RUN apt-get install npm --assume-yes
RUN npm install -g n
RUN npm install -g aws-cdk

COPY --from=build /app/bin .
COPY deployInfraSPA.sh .

ENTRYPOINT ["/deployInfraSPA.sh"]
