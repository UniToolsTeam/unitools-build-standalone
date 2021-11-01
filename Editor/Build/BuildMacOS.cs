using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.OSXStandalone;
using UnityEngine;

namespace UniTools.Build.Standalone
{
    [CreateAssetMenu(
        fileName = nameof(BuildMacOS),
        menuName = nameof(UniTools) + "/Build/Steps/" + nameof(Standalone) + "/" + nameof(BuildMacOS)
    )]
    public sealed class BuildMacOS : ScriptableBuildStepWithOptions
    {
        [SerializeField] private MacOSArchitecture m_architecture = default;
        [SerializeField] private bool m_createXcodeProject = false;

        public override BuildTarget Target => BuildTarget.StandaloneOSX;

        public override async Task<BuildReport> Execute()
        {
            UserBuildSettings.architecture = m_architecture;
            UserBuildSettings.createXcodeProject = m_createXcodeProject;
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();

            BuildReport report = UnityEditor.BuildPipeline.BuildPlayer(Options);

            await Task.CompletedTask;

            return report;
        }
    }
}