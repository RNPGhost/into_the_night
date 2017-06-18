using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelButton : MonoBehaviour {

  [SerializeField]
  private float buttonWidth;
  [SerializeField]
  private float buttonHeight;
  [SerializeField]
  private float verticalOffset;
  [SerializeField]
  private GameController gameController;

  private void OnGUI() {
    if (GUI.Button(new Rect((Screen.width - buttonWidth)/2, (Screen.height - buttonHeight)/2 + verticalOffset, buttonWidth, buttonHeight), "Start")) {
      gameController.StartLevel();
    }
  }
}
