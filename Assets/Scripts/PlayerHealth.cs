using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {

  [SerializeField]
  private int startLives;

  private int livesRemaining;

  private void Start() {
    livesRemaining = startLives;
  }

  protected void DestroySelf() {
    livesRemaining--;
    if (livesRemaining == 0) {
      scoreController.SaveScore();
    }
    // TODO: Reset level
    // TODO: Go invisible temporarily
  }
}
