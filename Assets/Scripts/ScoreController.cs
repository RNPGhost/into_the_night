using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

  [SerializeField]
  private NumericalValueUIController scoreUIController;
  [SerializeField]
  private NumericalValueUIController highScoreUIController;

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
    ResetScore();
    UpdateHighScore();
  }
  
  public void AddToScore(float scoreIncrease) {
    SetScore(score + scoreIncrease);
  }

  public void ResetScore() {
    SetScore(0);
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
    highScoreUIController.UpdateValueText(highScore);
  }

  private void SetScore(float newScore) {
    score = newScore;
    scoreUIController.UpdateValueText(score);
  }

  private float GetHighScore() {
    return PlayerPrefs.GetFloat(HIGH_SCORE_VARIABLE_NAME, 0);
  }

  private void SetHighScore(float highScore) {
    PlayerPrefs.SetFloat(HIGH_SCORE_VARIABLE_NAME, score);
  }
}
