using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectFactory
{
    [MenuItem("Assets/Scriptable Object/NewScriptable Object")]
    public static void CreateConfiguration()
    {
        Assembly assembly = GetAssembly();
        Type[] allScriptableObjects = (from t in assembly.GetTypes()
                                    where t.IsSubclassOf(typeof(ScriptableObject))
                                    select t).ToArray();

        ScriptableObjectWindow window = EditorWindow.GetWindow<ScriptableObjectWindow>(true, "Create a new Scriptable Object", true);
        
        window.ShowPopup();
        window.Types = allScriptableObjects;
    }

    static Assembly GetAssembly()
    {
        return Assembly.Load(new AssemblyName("Assembly-CSharp"));
    }
}