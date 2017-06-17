using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

  [SerializeField]
  private ScoreController scoreController;
  [SerializeField]
  private float maxOffset;
  [SerializeField]
  private GameObject asteroid;
  [SerializeField]
  private float delayBeforeAnySpawns;
  [SerializeField]
  private float initialDelayBetweenSpawns;
  [SerializeField]
  private float minSpawnDelay;
  [SerializeField]
  private float delayDecayRate;
  [SerializeField]
  private Transform target;
  [SerializeField]
  private float initialObstacleSpeed;
  [SerializeField]
  private float obstacleSpeedIncreaseRate;

  private float spawnDelay;
  private float spawnTimer;
  private float obstacleSpeed;
  private bool allowSpawning;

  private void Start() {
    spawnTimer = 0;
    StartSpawning();
  }

  public void ResetSpawning() {
    StopSpawning();
    StartSpawning();
  }

  private void StopSpawning() {
    allowSpawning = false;
  }

  private void StartSpawning() {
    spawnDelay = initialDelayBetweenSpawns;
    obstacleSpeed = initialObstacleSpeed;
    spawnTimer = delayBeforeAnySpawns;
    allowSpawning = true;
  }

  private void Update() {
    spawnTimer -= Time.deltaTime;
    if (allowSpawning && (spawnTimer <= 0)) {
      spawnDelay = Mathf.Max(minSpawnDelay, spawnDelay - delayDecayRate);
      obstacleSpeed += obstacleSpeedIncreaseRate;
      spawnTimer = spawnDelay;
      SpawnObstacle(asteroid, obstacleSpeed);
    }
  }

  private void SpawnObstacle(GameObject obstacle, float speed) {
    Vector3 objectPosition = gameObject.transform.position;
    float offset = maxOffset * Random.Range(-1.0f, 1.0f);
    Vector3 spawnPosition = new Vector3(objectPosition.x + offset, objectPosition.y, objectPosition.z);
    GameObject spawnedObstacle = Instantiate(obstacle, spawnPosition, gameObject.transform.rotation) as GameObject;

    spawnedObstacle.GetComponent<ObstacleHealth>().SetScoreController(scoreController);

    float targetOffset = maxOffset * Random.Range(-1.0f, 1.0f);
    Vector3 targetPosition = new Vector3(target.position.x + targetOffset, target.position.y, target.position.z);
    spawnedObstacle.GetComponent<SingleDirectionMover>().SetVelocity(speed * (targetPosition - spawnPosition).normalized);
  }
}
