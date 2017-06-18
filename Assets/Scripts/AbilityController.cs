using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

  [SerializeField]
  private Ability currentAbility;

	public void ActivateAbility() {
    currentAbility.Activate();
  }
}
