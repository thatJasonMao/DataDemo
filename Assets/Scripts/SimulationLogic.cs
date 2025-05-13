using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationLogic : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void OnDestroy()
    {
        AI_Reference.Instance.OnSceneQuit();
    }
}
