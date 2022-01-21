namespace Overlord.Core.CustomConstructs;

using Amazon.CDK;
using Amazon.CDK.AWS.EC2;

internal sealed class MainVpc : Vpc
{
    public MainVpc(Stack scope)
        : base(scope, "MainVpc", new VpcProps
        {
            VpcName = "MainVpc",
            NatGateways = 0,
            SubnetConfiguration = new ISubnetConfiguration[]
            {
                new SubnetConfiguration
                {
                    Name = "MainVpcSubnet",
                    SubnetType = SubnetType.PUBLIC,
                },
            },
        })
    { }
}
