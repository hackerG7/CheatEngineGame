using System.Collections;
using System.Collections.Generic;
using GKCore.Observers;
using Sirenix.OdinInspector;
using UltEvents;
using UnityEngine;

public class HierarchyStringBuilder : GKBehaviour{
    [Header("References")]
    public GameObject letterPrefab;

    #region Current String
    [Header("Variables")]
    public StringVar currentString;

    public void SetCurrentString(string str){
        if(currentString.Value == str)
            return;
        currentString.Value = str;
    }

    void Awake(){
        currentString.onChanged += OnCurrentStringChanged;
    }

    // Rebuild the string when the current string changes
    void OnCurrentStringChanged(string oldString, string newString){
        if(oldString == newString)
            return;
        TryRebuild();
    }
    #endregion

    #region Building
    public bool isRebuilding = false;
    void Start(){
        TryRebuild();
    }
    [Button]
    public void TryRebuild(){
        // STEP 1: Skip if we are rebuilding
        if(isRebuilding)
            return;

        Rebuild();
    }
    void Rebuild(){
        isRebuilding = true;
        Clear();
        Build();
        isRebuilding = false;
    }

    void Clear(){
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in transform){
            children.Add(child.gameObject);
        }
        foreach (GameObject child in children){
            DestroyImmediate(child);
        }
    }
    
    void Build(){
        string str = currentString.Value;

        // STEP 2: Add the new string, at the last sibling index
        for (int i = 0; i < str.Length; i++){
            GameObject letter = Instantiate(letterPrefab, transform);
            // letter.transform.SetAsLastSibling();
            letter.GetComponent<StringVarHolder>().Value = str[i].ToString();
        }

        Debug.Log("Rebuilding string: " + str);
        Debug.Log("current children after rebuilding: " + transform.childCount);
    }
    #endregion

    #region Load From Children
    public bool shouldLoadFromChildren = true;
    // Update the string when children are added or removed
    void OnTransformChildrenChanged(){
        // STEP 1: Skip if we are rebuilding
        if(isRebuilding)
            return;
        
        shouldLoadFromChildren = true;
    }
    void LateUpdate(){
        if(shouldLoadFromChildren){
            SetCurrentString(LoadStringFromChildren());
            shouldLoadFromChildren = false;
        }
    }

    string LoadStringFromChildren(){
        string str = "";
        foreach (Transform child in transform){
            var stringVarHolder = child.GetComponent<StringVarHolder>();
            if (stringVarHolder != null) {
                str += stringVarHolder.Value;
                Debug.Log($"Child value: {stringVarHolder.Value}");
            } else {
                Debug.LogWarning("Child missing StringVarHolder component");
            }
        }
        return str;
    }
    #endregion

}