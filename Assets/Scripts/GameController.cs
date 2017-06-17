using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  [SerializeField]
  private ObstacleSpawner obstacleSpawner;
  [SerializeField]
  private ScoreController scoreController;
  [SerializeField]
  private int startLives;

  private int livesRemaining;

  private void Start() {
    livesRemaining = startLives;
  }

  public void PlayerDestroyed() {
    obstacleSpawner.ResetSpawning();
    ClearAllObstacles();

    livesRemaining--;
    if (livesRemaining == 0) {
      // Game Over
      scoreController.SaveScore();
    }
  }

  private void ClearAllObstacles() {
    foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle")) {
      Destroy(obstacle);
    }
  }
}
