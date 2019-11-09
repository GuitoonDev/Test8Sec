using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private BallData ballData = null;

    private void Awake() {
        ballData.Reset();
    }
}
