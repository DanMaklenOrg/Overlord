using Amazon.CDK;
using Overlord.Core;

App app = new App();
CoreStack _ = new CoreStack(app);
app.Synth();
