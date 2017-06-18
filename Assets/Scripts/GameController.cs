using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  [SerializeField]
  private GameObject levelUI;
  [SerializeField]
  private GameObject endScreenUI;
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
    respawnPlayer = false;
    playerSpawnTimer = 0;
  }

  public void StartLevel() {
    livesRemaining = startLives;
    livesUIController.UpdateValueText(livesRemaining);
    respawnPlayer = true;
    playerSpawnTimer = 0;
    SetLevelUI();
    scoreController.ResetScore();
    obstacleSpawner.ResetSpawning();
  }

  public void PlayerDestroyed() {
    ClearAllObstacles();

    livesRemaining--;
    if (livesRemaining == 0) {
      respawnPlayer = false;
      scoreController.SaveScore();
      obstacleSpawner.StopSpawning();
      SetEndScreenUI();
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

  private void SetLevelUI() {
    levelUI.SetActive(true);
    endScreenUI.SetActive(false);
  }

  private void SetEndScreenUI() {
    levelUI.SetActive(false);
    endScreenUI.SetActive(true);
  }
}
