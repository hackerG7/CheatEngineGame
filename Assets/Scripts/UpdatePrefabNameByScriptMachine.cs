#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class UpdatePrefabNameByScriptMachine : MonoBehaviour
{
    public string prefix = "Prefab - ";
    [Button]
    public void UpdateName(){
        ScriptMachine scriptMachine = GetComponent<ScriptMachine>();
        if(scriptMachine != null){
            string newName = prefix + scriptMachine.graph.title;
            if(name != newName){
                name = newName;
            }
        }

        //Save Prefab
        PrefabUtility.RecordPrefabInstancePropertyModifications(this);
    }
    void OnValidate(){
        UpdateName();
    }
}

#endif