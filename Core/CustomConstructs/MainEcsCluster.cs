namespace Overlord.Core.CustomConstructs;

using Amazon.CDK;
using Amazon.CDK.AWS.EC2;
using Amazon.CDK.AWS.ECS;

internal sealed class MainEcsCluster : Cluster
{
    public MainEcsCluster(Stack scope, Vpc vpc)
        : base(scope, "MainEcsCluster", new ClusterProps
        {
            Vpc = vpc,
        })
    {
        this.AddCapacity("SingleEc2Node", new AddCapacityOptions
        {
            InstanceType = new InstanceType("t2.micro"),
        });
    }
}
