namespace Overlord.Core;

using Amazon.CDK;

internal static class Program
{
    public static void Main()
    {
        App app = new App();
        CoreStack _ = new CoreStack(app);
        app.Synth();
    }
}
