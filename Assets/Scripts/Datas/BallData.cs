using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "BallData", menuName = "Game/Ball Data")]
public class BallData : ScriptableObject
{
    public UnityAction<bool> OnEndLevel;

    [SerializeField] private LevelBallAvailability[] levelBallAvailabilityArray = null;

    public LevelBallAvailability[] LevelBallAvailabilityArray => levelBallAvailabilityArray;

    public int BallsToSpawnCount { get; set; }

    private int ballsDestroyedCount;

    public void OnBallDestroyed() {
        ballsDestroyedCount++;

        if (BallsToSpawnCount == ballsDestroyedCount) {
            OnEndLevel(true);
        }
    }

    public void OnGameOver() {
        OnEndLevel(false);
    }

    public void Reset() {
        BallsToSpawnCount = 0;
        ballsDestroyedCount = 0;
    }
}
