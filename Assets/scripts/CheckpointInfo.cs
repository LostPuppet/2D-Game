using System;
using UnityEngine;

[Serializable]
public class CheckpointInfo
{
    [SerializeField] private int checkpointID;
    [SerializeField] private string sceneName;

    public int ID => checkpointID;
    public string SceneName => sceneName;
}