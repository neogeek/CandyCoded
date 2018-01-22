using System;
#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
#endif
using UnityEngine;

[System.AttributeUsage(System.AttributeTargets.Method)]
public class DisplayInInsepctorAttribute : PropertyAttribute { }

#if UNITY_EDITOR
[CustomEditor(typeof(MonoBehaviour), true)]
public class DisplayInInsepctorDrawer : Editor
{

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        MemberInfo[] methods = target.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (MemberInfo method in methods)
        {

            if (Attribute.IsDefined(method, typeof(DisplayInInsepctorAttribute)))
            {

                if (GUILayout.Button(ObjectNames.NicifyVariableName(method.Name)))
                {

                    ((MethodInfo) method).Invoke(target, null);

                }

            }

        }

    }

}
#endif
