FROM mcr.microsoft.com/dotnet/sdk:6.0

RUN apt-get update --assume-yes
RUN apt-get install jq --assume-yes
RUN apt-get install npm --assume-yes
RUN npm install -g n
RUN npm install -g aws-cdk

COPY bin/Release/net6.0/publish .
COPY deployInfraSPA.sh .

ENTRYPOINT ["./deployInfraSPA.sh"]
