using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private string InfoFolder = string.Empty;

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        Debug.Log($"Current Agent Count:{AI_Reference.Instance.SceneNPCs.Count}");
    }
}
