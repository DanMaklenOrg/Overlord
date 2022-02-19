namespace Overlord.Infra.SinglePageApplicationWebsite.Constructs;

using Amazon.CDK;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.AWS.S3.Deployment;
using global::Constructs;

internal class SinglePageApplicationStack : Stack
{
    public SinglePageApplicationStack(Construct scope, Config config)
        : base(scope, $"{config.Name}-stack", new StackProps
        {
            Description = "Holds the required resources to deploy and publish a single page application (SPA) website.",
            TerminationProtection = true,
        })
    {
        Bucket bucket = new Bucket(this, "hosting-bucket", new BucketProps
        {
            BucketName = $"{config.Name.ToLower()}-hosting-bucket",
            WebsiteIndexDocument = "index.html",
            PublicReadAccess = true,
            RemovalPolicy = RemovalPolicy.DESTROY,
            AutoDeleteObjects = true,
        });

        BucketDeployment _ = new BucketDeployment(this, "deployment-files", new BucketDeploymentProps
        {
            Sources = new[] { Source.Asset(config.WebsiteResourcesDir) },
            DestinationBucket = bucket,
        });
    }
}
