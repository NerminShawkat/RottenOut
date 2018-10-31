using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Kandooz {
    [CustomEditor(typeof(ColorField))]
    public class ColorFIeldEditor : Editor {
        ColorField color;

        //public override void OnInspectorGUI()
        //{
        //    color = (ColorField)target;
        //    EditorGUI.BeginChangeCheck();

        //    color.Value = EditorGUILayout.ColorField(new GUIContent("color"),color.Value,true,true,true);
        //    if (EditorGUI.EndChangeCheck())
        //    {
        //        Undo.RegisterCompleteObjectUndo(color, "color changed");
        //    }
        //}

    }
}