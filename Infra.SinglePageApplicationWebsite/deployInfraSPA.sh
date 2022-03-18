#!/bin/sh -l

set -e

echo "AWS_ACCESS_KEY_ID = $AWS_ACCESS_KEY_ID"
echo "AWS_SECRET_ACCESS_KEY = $AWS_SECRET_ACCESS_KEY"
echo "AWS_DEFAULT_REGION = $AWS_DEFAULT_REGION"

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
  -c CertificateArn="$certificateArn" \
  --dry-run --profile=personal

bucketArn=$(jq ".[].bucketName" $outputFile)
edgeDomain=$(jq ".[].edge-distribute-endpoint" $outputFile)

echo "Reminder: add CNAME record to your domain \`$domainName\` with value \`$edgeDomain\`"
echo "::setOutputs name=bucketArn::$bucketArn"
