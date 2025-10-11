using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace AudioButton
{
    internal static class SourceGenerator
    {
        public static void Generate(IEnumerable<AudioClip> sources)
        {

            var result      = EnumGenerator.Gen(sources.Select(source => source.name));
            string savePath = Application.dataPath + "/AudioButton/SoundId.cs";

            try
            {
                Save(result, savePath);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }

            AssetDatabase.Refresh();
        }

        private static void Save(string content, string path)
        {
            Debug.Log(path);

            File.WriteAllText(path, content);
        }
    }
}
#endif
