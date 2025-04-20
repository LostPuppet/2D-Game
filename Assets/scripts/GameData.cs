using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public float currentTime;
    public int currentCheckpoint;

    public void SetCheckpoint(int checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void Tick(float deltaTime)
    {
        currentTime += deltaTime;
    }

    public void ResetTime()
    {
        currentTime = 0f;
    }
}