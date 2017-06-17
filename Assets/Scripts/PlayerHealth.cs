using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {

  [SerializeField]
  private GameController gameController;

  override protected void DestroySelf() {
    // TODO: Go invisible temporarily
    gameController.PlayerDestroyed();
  }
}
