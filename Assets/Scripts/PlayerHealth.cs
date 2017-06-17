using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {

  [SerializeField]
  private ScoreController scoreController;
  [SerializeField]
  private int startLives;

  private int livesRemaining;

  override protected void Initialization() {
    base.Initialization();
    livesRemaining = startLives;
  }

  override protected void DestroySelf() {
    livesRemaining--;
    if (livesRemaining == 0) {
      scoreController.SaveScore();
    } else {
      // TODO: Go invisible temporarily
    }
    // TODO: Reset level
  }
}
