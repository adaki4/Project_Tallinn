using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float minimumSpawnTime;
    [SerializeField]
    private float maximumSpawnTime;
    private float timeUntilSpawn;
    private Vector3 spawnPosition;
    void Start()
    {
        SetTimeUntilSpawn();
        SetSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn < 0) {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            SetTimeUntilSpawn();
            SetSpawnPosition();
        }
    }

    private void SetSpawnPosition() {
        float ySpawnPosition = Random.Range(CameraManager.instance.minimalScreenPosition.y, CameraManager.instance.topScreenLimit);
        spawnPosition = new Vector3(transform.position.x, ySpawnPosition);
    }
    private void SetTimeUntilSpawn() {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
