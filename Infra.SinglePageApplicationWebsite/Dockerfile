FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY bin/Release/net6.0/Constructs.dll .
COPY bin/Release/net6.0/Amazon.CDK.Lib.dll .
COPY bin/Release/net6.0/Infra.SinglePageApplicationWebsite .
COPY deployInfraSPA.sh .

ENTRYPOINT deployInfraSpa.sh
