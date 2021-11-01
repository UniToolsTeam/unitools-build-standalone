using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace UniTools.Build.Standalone
{
    [CreateAssetMenu(
        fileName = nameof(BuildWindows64),
        menuName = nameof(UniTools) + "/Build/Steps/" + nameof(Standalone) + "/" + nameof(BuildWindows64)
    )]
    public sealed class BuildWindows64 : ScriptableBuildStepWithOptions
    {
        public override BuildTarget Target => BuildTarget.StandaloneWindows64;

        public override async Task<BuildReport> Execute()
        {
            BuildReport report = UnityEditor.BuildPipeline.BuildPlayer(Options);

            await Task.CompletedTask;

            return report;
        }
    }
}