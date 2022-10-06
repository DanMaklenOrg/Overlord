FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app

COPY Infra.SinglePageApplicationWebsite.csproj .

RUN dotnet restore

COPY . .

RUN dotnet publish -o bin -c Release --no-restore

FROM mcr.microsoft.com/dotnet/sdk:6.0

RUN apt-get update -y
RUN apt-get install jq -y
RUN apt-get install nodejs npm -y
RUN npm install -g aws-cdk
RUN npm install -g n
RUN n stable

COPY --from=build /app/bin .
COPY deployInfraSPA.sh .

ENTRYPOINT ["/deployInfraSPA.sh"]
