FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app

COPY Infra.SinglePageApplicationWebsite.csproj .

RUN dotnet restore

COPY . .

RUN dotnet publish -o out -c Release --no-restore

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app

RUN apt-get update --assume-yes
RUN apt-get install jq --assume-yes
RUN apt-get install npm --assume-yes
RUN npm install -g n
RUN npm install -g aws-cdk

COPY --from=build /app/out .
COPY deployInfraSPA.sh .

RUN echo $(ls -al)

ENTRYPOINT ["./deployInfraSPA.sh"]
