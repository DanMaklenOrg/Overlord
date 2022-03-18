#!/bin/sh -l

set -e

name=$1
domainName=$2
certificateArn=$3

outputFile="cdk.out/outputs.json"

echo "Running CDK deploy"
cdk deploy \
  --app=/Infra.SinglePageApplicationWebsite \
  --require-approval never \
  --outputs-file $outputFile \
  -c Name="$name" \
  -c DomainName="$domainName" \
  -c CertificateArn="$certificateArn"

bucketName=$(jq -r '.[].bucketName' $outputFile)
edgeDomain=$(jq -r '.[].edgeDistributeEndpoint' $outputFile)

echo "Reminder: add CNAME record to your domain \`$domainName\` with value \`$edgeDomain\`"
echo "::setOutputs name=bucketName::$bucketName"
