FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY --from=build-env out .
COPY deployInfraSPA.sh .

ENTRYPOINT deployInfraSpa.sh
