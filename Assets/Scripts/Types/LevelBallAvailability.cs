using UnityEngine;

[System.Serializable]
public class LevelBallAvailability
{
    [SerializeField, Range(1, 20)] private int availableLevel = 1;
    [SerializeField] private Ball[] ballArray = null;

    public int AvailableLevel => availableLevel;
    public Ball[] BallArray => ballArray;
}
