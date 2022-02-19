using Amazon.CDK;
using Overlord.Infra.SinglePageApplicationWebsite.Constructs;

App app = new App();
Config config = Config.FromContext(app);
Stack _ = new SinglePageApplicationStack(app, config);
app.Synth();