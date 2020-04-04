/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2020 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\Editor\ULuaPanelInspector.cs
| AUTHOR     : http://supercline.com/
| PURPOSE    :
|
| SPEC       :
|
| MODIFICATION HISTORY
|
| Ver      Date            By              Details
| -----    -----------    -------------   ----------------------
| 1.0      2020-4-4      SuperCLine           Created
|
+-----------------------------------------------------------------------------*/

namespace CAE.Core
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(ULuaPanel))]
    public sealed class ULuaPanelInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.BeginVertical("box");

            SerializedProperty sp = serializedObject.FindProperty("LuaPanelName");
            EditorGUILayout.PropertyField(sp, new GUIContent("Lua脚本"));

            sp = serializedObject.FindProperty("Layer");
            EditorGUILayout.PropertyField(sp, new GUIContent("层级"));

            sp = serializedObject.FindProperty("Mask");
            EditorGUILayout.PropertyField(sp, new GUIContent("是否显示Mask"));

            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }

}