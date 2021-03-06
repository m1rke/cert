using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

// This is a script that implement build process with CLI for Unity3D projects.
// MAINTAINER Mirnes Halilovic <mirnes.halilovic@serapion.net>
// The pipeline is made up of 2 main steps:
//     1. Build Android App
//     2. Build IOS App

public class SerapionBuild : MonoBehaviour
{
    [MenuItem("Build/Build iOS")]
    public static void IphoneApp()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Scenes/MainMenuScene.unity", 
                                           "Assets/Scenes/MainScene.unity",
                                           "Assets/Scenes/LevelCreatorScene.unity"};
        buildPlayerOptions.locationPathName = "build/iPhone/";
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Serapion IOS Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Serapion IOS Build failed");
        }
    }

    [MenuItem("Build/Build Android")]
    public static void AndroidApp()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Scenes/MainMenuScene.unity", 
                                           "Assets/Scenes/MainScene.unity",
                                           "Assets/Scenes/LevelCreatorScene.unity"};
        buildPlayerOptions.locationPathName = "build/android/kenningDemoFinal.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Serapion ANDROID Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Serapion ANDROID Build failed");
        }
    }
}
