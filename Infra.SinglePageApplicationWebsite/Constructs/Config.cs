namespace Overlord.Infra.SinglePageApplicationWebsite.Constructs;

using Amazon.CDK;

internal readonly struct Config
{
    internal string Name { get; private init; }

    internal string WebsiteResourcesDir { get; private init; }

    internal static Config FromContext(App app)
    {
        return new Config
        {
            Name = Convert.ToString(app.Node.TryGetContext("Name")) ?? string.Empty,
            WebsiteResourcesDir = Convert.ToString(app.Node.TryGetContext("WebsiteResourcesDir")) ?? string.Empty,
        };
    }
}
