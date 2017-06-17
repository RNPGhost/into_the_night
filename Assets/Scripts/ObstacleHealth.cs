using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHealth : Health {

  [SerializeField]
  private float scoreValue;

  private ScoreController scoreController;

  public void SetScoreController(ScoreController newScoreController) {
    scoreController = newScoreController;
  }

  protected override void DestroySelf() {
    AddToScore();
    base.DestroySelf();
  }

  private void AddToScore() {
    scoreController.AddToScore(scoreValue);
  }
}
