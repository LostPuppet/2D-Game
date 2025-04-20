using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CheckpointDatabase", menuName = "ScriptableObjects/CheckpointDatabase", order = 2)]
public class CheckpointDatabase : ScriptableObject
{
    [SerializeField] private List<CheckpointInfo> checkpoints = new List<CheckpointInfo>();

    public string GetSceneNameForCheckpoint(int id)
    {
        var info = checkpoints.Find(cp => cp.ID == id);
        return info != null ? info.SceneName : null;
    }
}