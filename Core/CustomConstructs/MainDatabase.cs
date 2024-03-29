using Amazon.CDK;
using Amazon.CDK.AWS.EC2;
using Amazon.CDK.AWS.RDS;

namespace Overlord.Core.CustomConstructs;

public class MainDatabase : DatabaseInstance
{
    public MainDatabase(Stack scope, Vpc mainVpc) : base(scope, "db", new DatabaseInstanceProps
    {
        InstanceIdentifier = "MainDb",
        Vpc = mainVpc,
        VpcSubnets = new SubnetSelection
        {
            SubnetType = SubnetType.PUBLIC,
        },
        Engine = DatabaseInstanceEngine.POSTGRES,
        InstanceType = InstanceType.Of(InstanceClass.BURSTABLE3, InstanceSize.MICRO),
        AllocatedStorage = 20.0,
    })
    {
    }
}
