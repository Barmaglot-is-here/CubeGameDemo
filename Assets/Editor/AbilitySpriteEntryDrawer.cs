using Game.Abilities;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    [CustomPropertyDrawer(typeof(AbilitySpriteSheet.Entry))]
    public class AbilitySpriteEntryDrawer : PropertyDrawer
    {
        private static readonly Type[] _abilityTypes = TypeCache.GetTypesDerivedFrom<BaseAbility>()
                                                               .Where(type => !type.IsAbstract && !type.ContainsGenericParameters)
                                                               .OrderBy(type => type.FullName)
                                                               .ToArray();

        private static readonly string[] _typeNames = new[] { "None" }
                                                     .Concat(_abilityTypes.Select(type => type.FullName))
                                                     .ToArray();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var typeProperty = property.FindPropertyRelative("<AbilityTypeName>k__BackingField");
            var spriteProperty = property.FindPropertyRelative("<Sprite>k__BackingField");
            string typeName = typeProperty.stringValue;
            int selectedIndex = Array.FindIndex(_abilityTypes, type => type.AssemblyQualifiedName == typeName) + 1;
            string[] options = _typeNames;

            if (selectedIndex == 0 && !string.IsNullOrEmpty(typeName))
            {
                options = _typeNames.Concat(new[] { $"Missing: {typeName}" }).ToArray();
                selectedIndex = options.Length - 1;
            }

            Rect row = new(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.showMixedValue = typeProperty.hasMultipleDifferentValues;
            EditorGUI.BeginChangeCheck();
            int newIndex = EditorGUI.Popup(row, "Ability", selectedIndex, options);

            if (EditorGUI.EndChangeCheck() && newIndex <= _abilityTypes.Length)
                typeProperty.stringValue = newIndex == 0 ? string.Empty : _abilityTypes[newIndex - 1].AssemblyQualifiedName;

            EditorGUI.showMixedValue = false;
            row.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            EditorGUI.PropertyField(row, spriteProperty, new GUIContent("Sprite"));

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 2 + EditorGUIUtility.standardVerticalSpacing;
        }
    }
}
