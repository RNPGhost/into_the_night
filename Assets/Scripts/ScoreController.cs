using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

  [SerializeField]
  private NumericalValueUIController scoreUIController;
  [SerializeField]
  private NumericalValueUIController endScoreUIController;
  [SerializeField]
  private NumericalValueUIController highScoreUIController;
  [SerializeField]
  private NewHighscoreUIController newHighscoreUIController;

  private const string HIGH_SCORE_VARIABLE_NAME = "High Score";

  private float score;

  public float Score {
    get {
      return score;
    }
  }
  
  public void AddToScore(float scoreIncrease) {
    SetScore(score + scoreIncrease);
  }

  public void ResetScore() {
    SetScore(0);
    UpdateHighScore();
    newHighscoreUIController.ResetText();
  }

  public void SaveScore() {
    UpdateHighScore();
  }

  private void UpdateHighScore() {
    float highScore = GetHighScore();
    if (score > highScore) {
      SetHighScore(score);
      highScore = score;
      newHighscoreUIController.SetTextForNewHighscore();
    }
    highScoreUIController.UpdateValueText(highScore);
  }

  private void SetScore(float newScore) {
    score = newScore;
    scoreUIController.UpdateValueText(score);
    endScoreUIController.UpdateValueText(score);
  }

  private float GetHighScore() {
    return PlayerPrefs.GetFloat(HIGH_SCORE_VARIABLE_NAME, 0);
  }

  private void SetHighScore(float highScore) {
    PlayerPrefs.SetFloat(HIGH_SCORE_VARIABLE_NAME, score);
  }
}
