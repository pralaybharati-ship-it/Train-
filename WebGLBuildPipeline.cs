#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace RunawayTrain.Editor
{
    public static class WebGLBuildPipeline
    {
        public static void Build()
        {
            PlayerSettings.productName = "RUNAWAY TRAIN";
            PlayerSettings.companyName = "PRALAY";
            PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;
            PlayerSettings.WebGL.dataCaching = true;
            PlayerSettings.WebGL.exceptionSupport = WebGLExceptionSupport.None;

            var scenes = new[]
            {
                "Assets/RunawayTrain/Scenes/RunawayTrain.unity"
            };

            var options = new BuildPlayerOptions
            {
                scenes = scenes,
                locationPathName = "build/WebGL",
                target = BuildTarget.WebGL,
                options = BuildOptions.None
            };

            var report = BuildPipeline.BuildPlayer(options);

            if (report.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
                throw new System.Exception("RUNAWAY TRAIN WebGL build failed.");
        }
    }
}
#endif
