using Amazon.CDK;
using Amazon.CDK.AWS.EC2;
using Amazon.CDK.AWS.RDS;

namespace Overlord.Core.CustomConstructs;

public class MainDatabase : DatabaseInstance
{
    public MainDatabase(Stack scope, Vpc mainVpc) : base(scope, "mainDb", new DatabaseInstanceProps
    {
        InstanceIdentifier = "MainDatabase",
        Vpc = mainVpc,
        VpcSubnets = new SubnetSelection
        {
            SubnetType = SubnetType.PUBLIC,
        },
        Engine = DatabaseInstanceEngine.POSTGRES,
    })
    {
    }
}
