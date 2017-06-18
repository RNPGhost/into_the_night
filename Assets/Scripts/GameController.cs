using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  [SerializeField]
  private NumericalValueUIController livesUIController;
  [SerializeField]
  private ObstacleSpawner obstacleSpawner;
  [SerializeField]
  private ScoreController scoreController;
  [SerializeField]
  private int startLives;
  [SerializeField]
  private float playerSpawnDelay;
  [SerializeField]
  private GameObject player;

  private int livesRemaining;
  private bool respawnPlayer;
  private float playerSpawnTimer;

  private void Start() {
    livesRemaining = startLives;
    livesUIController.UpdateValueText(livesRemaining);
    respawnPlayer = true;
    playerSpawnTimer = 0;
  }

  public void PlayerDestroyed() {
    ClearAllObstacles();

    livesRemaining--;
    if (livesRemaining == 0) {
      respawnPlayer = false;
      scoreController.SaveScore();
      obstacleSpawner.StopSpawning();
    } else {
      obstacleSpawner.ResetSpawning();
      playerSpawnTimer = playerSpawnDelay;
    }
    livesUIController.UpdateValueText(livesRemaining);
  }

  private void ClearAllObstacles() {
    foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle")) {
      Destroy(obstacle);
    }
  }

  private void Update() {
    playerSpawnTimer -= Time.deltaTime;
    if (respawnPlayer && (playerSpawnTimer <= 0)) {
      player.SetActive(true);
    }
  }
}
