#!/bin/sh -l

set -e

echo "$GITHUB_ACTIONS"
echo "$AWS_DEFAULT_REGION"
echo $GITHUB_ACTIONS
echo $AWS_DEFAULT_REGION

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
