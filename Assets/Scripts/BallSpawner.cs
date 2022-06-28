using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [field: SerializeField]
    private GameObject BallPrefab { get; set; }

    public void SpawnNewBall()
    {
        Instantiate(BallPrefab);
    }
}
