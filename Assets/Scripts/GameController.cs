using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  [SerializeField]
  private ObstacleSpawner obstacleSpawner;
  
  public void LifeLost() {
    obstacleSpawner.ResetSpawning();
    ClearAllObstacles();
  }

  private void ClearAllObstacles() {
    foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle")) {
      Destroy(obstacle);
    }
  }
}
