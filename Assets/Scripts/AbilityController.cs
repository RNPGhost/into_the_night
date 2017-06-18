using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

  [SerializeField]
  private Ability currentAbility;

  public Ability CurrentAbility {
    get {
      return currentAbility;
    }
  }

  public void ActivateAbility() {
    CurrentAbility.Activate();
  }

  public void ResetCooldown() {
    CurrentAbility.ResetCooldown();
  }
}
