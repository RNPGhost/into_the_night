using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHighscoreUIController : MonoBehaviour {

  [SerializeField]
  private Text textUI;
  [SerializeField]
  private string newHighscoreText;

  public void ResetText() {
    textUI.text = "";
  }

  public void SetTextForNewHighscore() {
    textUI.text = newHighscoreText;
  }
}
