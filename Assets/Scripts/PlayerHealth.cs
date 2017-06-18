using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {

  [SerializeField]
  private GameController gameController;

  override protected void DestroySelf() {
    gameObject.SetActive(false);
    gameController.PlayerDestroyed();
  }
}
