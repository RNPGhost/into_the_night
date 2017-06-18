using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

  private const string HIGH_SCORE_VARIABLE_NAME = "High Score";

  private float score;

  public float Score {
    get {
      return score;
    }
  }

  private float highScore;

  public float HighScore {
    get {
      return highScore;
    }
  }

  private void Start() {
    score = 0;
    highScore = GetHighScore();
  }
  
  public void AddToScore(float scoreIncrease) {
    score += scoreIncrease;
    Debug.Log("Current score is " + score);
  }

  public void ResetScore() {
    score = 0;
  }

  public void SaveScore() {
    UpdateHighScore();
  }

  private void UpdateHighScore() {
    float highScore = GetHighScore();
    if (score > highScore) {
      SetHighScore(score);
      highScore = score;
    }
  }

  private float GetHighScore() {
    return PlayerPrefs.GetFloat(HIGH_SCORE_VARIABLE_NAME, 0);
  }

  private void SetHighScore(float highScore) {
    PlayerPrefs.SetFloat(HIGH_SCORE_VARIABLE_NAME, score);
  }
}
