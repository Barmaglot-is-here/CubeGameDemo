#if UNITY_EDITOR
using UnityEditor;

namespace AudioButton
{
    [CustomEditor(typeof(SoundPlayer))]
    internal class SoundPlayerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if (!DrawDefaultInspector() || !((SoundPlayer)target).AutoEnumGeneration)
                return;

            var soundList = serializedObject.FindProperty("_soundList").objectReferenceValue as SoundList;

            UpdateSoundList(soundList);
        }

        internal static void UpdateSoundList(SoundList soundList)
        {
            if (!FindFirstObjectByType<SoundPlayer>().AutoEnumGeneration)
                return;

            SourceGenerator.Generate(soundList.Sounds);
        }
    }
}
#endif
