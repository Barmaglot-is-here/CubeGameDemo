#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace AudioButton
{
    [InitializeOnLoad]
    [CustomEditor(typeof(SoundList))]
    internal class SoundListEditor : Editor
    {
        static SoundListEditor()
        {
            Undo.undoRedoPerformed += OnUndoRedo;
        }

        public override void OnInspectorGUI()
        {
            if (!DrawDefaultInspector())
                return;

            var soundList           = (SoundList)target;
            var attachedSoundList   = GetAttachedSoundList();

            if (soundList.Equals(attachedSoundList))
                SoundPlayerEditor.UpdateSoundList(soundList);
        }

        private static void OnUndoRedo()
        { 
            var soundList = GetAttachedSoundList();

            SoundPlayerEditor.UpdateSoundList(soundList);
        }

        private static SoundPlayer GetSoundPlayer () => GameObject.FindFirstObjectByType<SoundPlayer>();

        private static SoundList GetAttachedSoundList()
        {
            var soundPlayer = GetSoundPlayer();

            using SerializedObject serializedPlayer = new(soundPlayer);
            var soundList = serializedPlayer.FindProperty("_soundList").objectReferenceValue as SoundList;

            return soundList;
        }
    }
}
#endif
