using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private string InfoFolder = string.Empty;

    private static StreamWriter NPCWriter;

    private string NPCInfoHeader = "NPC_Simulation_Info_";

    private StringBuilder _buffer = new StringBuilder();

    private void Awake()
    {
        InitDirAndFileStream();
    }

    private void FixedUpdate()
    {
        Debug.Log($"Current Agent Count:{AI_Reference.Instance?.SceneNPCs.Count}");
        Record();
    }

    private void InitDirAndFileStream()
    {
        //根据受试者名称初始化记录路径
        if (Application.isEditor)
        {
            InfoFolder = Application.dataPath.Replace("/Assets", "") + "/SimulationData";
            if (!System.IO.Directory.Exists(InfoFolder))
            {
                System.IO.Directory.CreateDirectory(InfoFolder);
            }
        }

        else
        {
            InfoFolder = Application.dataPath.Substring(0, Application.dataPath.Length - 5) + "/SimulationData";
            if (!System.IO.Directory.Exists(InfoFolder))
            {
                System.IO.Directory.CreateDirectory(InfoFolder);
            }
        }

        Debug.Log("InfoWriter Directory Init Finish.");

        DateTime CurTime = DateTime.Now;
        string TimeStamp = CurTime.ToString("yyyy_MM_dd_HH_mm_ss");

        NPCWriter = new StreamWriter(InfoFolder + "/" + NPCInfoHeader + TimeStamp + ".csv", true);
        NPCWriter.WriteLine("TimeStamp,ID,PosX,PosY,PosZ");
    }

    private void Record()
    {
        foreach (var item in AI_Reference.Instance.SceneNPCs)
        { 
            Vector3 pos = item.transform.position;
            _buffer.Append(DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss.ffff")).Append(",").Append(item.name).Append(",").Append(pos.x).Append(",").Append(pos.y).Append(",").Append(pos.z).Append("\n");
        }
        NPCWriter.Write(_buffer.ToString());
        _buffer.Clear();
    }

    private void OnDestroy()
    { 
        _buffer.Clear();
        NPCWriter.Close();
    }
}
