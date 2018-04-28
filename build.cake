#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#tool Bumpy
#addin Cake.Bumpy
#addin nuget:?package=Cake.Git
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./src/Component/Furysoft.Versioning/bin") + Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreRestore("./src/Furysoft.Versioning.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    DotNetCoreBuild("./src/Furysoft.Versioning.sln",
            new DotNetCoreBuildSettings()
            {
                Configuration = configuration,
                ArgumentCustomization = args => args.Append("--no-restore"),
            });
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest("./src/Tests/Furysoft.Versioning.Tests/Furysoft.Versioning.Tests.csproj",
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true,
                    ArgumentCustomization = args => args.Append("--no-restore"),
                });
});

Task("Increment-Version")
    .IsDependentOn("Run-Unit-Tests")
    .Does(() =>
{
    BumpyIncrement(3);
});

Task("Package")
    .IsDependentOn("Increment-Version")
    .Does(() =>
{
    DotNetCorePack("./src/Component/Furysoft.Versioning/Furysoft.Versioning.csproj", new DotNetCorePackSettings
     {
         Configuration = configuration,
         NoRestore = true,
         NoBuild = true
    });
});

Task("Push-To-NuGet")
    .IsDependentOn("Package")
    .Does(() =>
{
var nugetKey=EnvironmentVariable("NugetApi");

      var settings = new DotNetCoreNuGetPushSettings
     {
         ApiKey = nugetKey,
         Source = "https://api.nuget.org/v3/index.json"
     };

     DotNetCoreNuGetPush("**/Furysoft.Versioning.*.nupkg", settings);
});

Task("Push-To-GitHub")
    .IsDependentOn("Push-To-NuGet")
    .Does(() =>
{
    var filePaths = new FilePath[] { "./src/Component/Furysoft.Versioning/Furysoft.Versioning.csproj" };
    GitAdd(".", filePaths);
    GitCommit(".", "name", "email", "message");
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Push-To-GitHub");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
