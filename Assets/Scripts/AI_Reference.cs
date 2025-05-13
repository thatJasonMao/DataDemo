using System.Collections.Generic;
using UnityEngine;

public class AI_Reference : MonoBehaviour
{
    public static List<GameObject> SceneNPCs;

    public static bool IsModifying = false;

    private int MaxGameObejctCount;

    private static AI_Reference instance;

    public static AI_Reference Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AI_Reference>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("AI_Reference");
                    instance = singletonObject.AddComponent<AI_Reference>();

                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    public void OnSceneInit()
    {
        SceneNPCs = new List<GameObject>(MaxGameObejctCount);
        Debug.Log("NPC Dynamic Container Init Finish.");
    }

    public void OnSceneQuit()
    {
        SceneNPCs.Clear();
        SceneNPCs = null;
        Debug.Log("NPC Dynamic Container Quit Flush.");
    }

    public void RegisterNPC(GameObject _NPC)
    {
        if (!SceneNPCs.Contains(_NPC))
        { 
            SceneNPCs.Add(_NPC);
        }
        Debug.Log($"Add New NPC: {_NPC.gameObject.name} Current NPC Count: {SceneNPCs.Count}");
    }

    public void UnRegisterNPC(GameObject _NPC)
    {
        if (SceneNPCs.Contains(_NPC))
        {
            SceneNPCs.Remove(_NPC);
            Debug.Log($"Remove NPC: {_NPC.gameObject.name} Current NPC Count: {SceneNPCs.Count}");
        }
    }
}
