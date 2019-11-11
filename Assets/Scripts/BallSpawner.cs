using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private BallData ballData = null;
    [SerializeField] private float spawnDelta = 1f;

    private bool spawnLastBall;

    private List<Ball> availableBallsList;
    private int spawnedBallsCount;

    private void Awake() {
        availableBallsList = new List<Ball>();
    }

    private void Start() {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        ballData.BallsToSpawnCount = 3 + currentLevel / 2 + currentLevel / 6;

        for (int i = 0; i < ballData.LevelBallAvailabilityArray.Length; i++) {
            if (ballData.LevelBallAvailabilityArray[i].AvailableLevel <= currentLevel) {
                availableBallsList.AddRange(ballData.LevelBallAvailabilityArray[i].BallArray);
            }
        }

        StartCoroutine(SpawningBallsCoroutine());
    }

    private IEnumerator SpawningBallsCoroutine() {
        float nextTimeToWait = 1.2f;

        while (ballData.BallsToSpawnCount > spawnedBallsCount) {
            yield return new WaitForSeconds(nextTimeToWait);

            Ball ballPrefabToSpawn = availableBallsList[Random.Range(0, availableBallsList.Count)];
            Ball newBall = Instantiate(ballPrefabToSpawn, transform.position, Quaternion.identity);

            nextTimeToWait = Random.Range(newBall.BouncesBeforeDestroy - 0.3f * newBall.BouncesBeforeDestroy, newBall.BouncesBeforeDestroy + 0.1f);

            float startPositionX = Random.Range(-spawnDelta, spawnDelta);
            startPositionX = (float) System.Math.Round(startPositionX, 1);
            newBall.transform.Translate(startPositionX, 0, 0);

            spawnedBallsCount++;
        }
    }
}
