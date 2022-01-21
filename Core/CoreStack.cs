namespace Overlord.Core;

using Amazon.CDK;
using Constructs;
using Overlord.Core.CustomConstructs;

internal sealed class CoreStack : Stack
{
    public CoreStack(Construct app)
        : base(app, "CoreStack")
    {
        MainVpc mainVpc = new MainVpc(this);
        MainEcsCluster _ = new MainEcsCluster(this, mainVpc);
    }
}
