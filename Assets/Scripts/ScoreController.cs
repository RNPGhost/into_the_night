using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

  private float score;

  private void Start() {
    score = 0;
  }
  
  public void AddToScore(float scoreIncrease) {
    score += scoreIncrease;
    Debug.Log("Current score is " + score);
  }

  public void SaveScore() {
    // TODO: Check against previous high score
  }
}
