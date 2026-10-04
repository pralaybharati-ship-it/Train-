#if UNITY_EDITOR
using UnityEditor;

namespace RunawayTrain.Editor
{
    public static class AndroidBuildPipeline
    {
        public static void Build()
        {
            var scenes = new[]
            {
                "Assets/RunawayTrain/Scenes/RunawayTrain.unity"
            };

            var options = new BuildPlayerOptions
            {
                scenes = scenes,
                locationPathName = "build/RunawayTrain.apk",
                target = BuildTarget.Android,
                options = BuildOptions.None
            };

            BuildPipeline.BuildPlayer(options);
        }
    }
}
#endif
