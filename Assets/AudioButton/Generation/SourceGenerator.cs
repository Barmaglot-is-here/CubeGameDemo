#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AudioButton
{
    internal static class SourceGenerator
    {
        public static void Generate(IEnumerable<AudioClip> sources)
        {
            var result      = EnumGenerationUtility.Gen(sources.Select(source => source.name));
            string savePath = Application.dataPath + "/AudioButton/SoundId.cs";

            try
            {
                if (!IsContentChanged(savePath, result))
                    return;

                Save(result, savePath);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);

                return;
            }

            AssetDatabase.Refresh();
        }

        private static bool IsContentChanged(string filePath, string content) 
            => File.Exists(filePath) && File.ReadAllText(filePath) != content;

        private static void Save(string content, string path) => File.WriteAllText(path, content);
    }
}
#endif
