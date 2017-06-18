using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWhirlwind : Ability {

  [SerializeField]
  private float abilityCooldown;
  [SerializeField]
  private float abilityDuration;
  [SerializeField]
  private BoltFirer boltFirer;
  [SerializeField]
  private float newBoltCooldown;

  private const string ABILITY_NAME = "Whirlwind";

  private bool activated;
  private float cooldownTimer;

  private void Start() {
    activated = false;
  }

  public override string GetName() {
    return ABILITY_NAME;
  }

  override public void Activate() {
    if (CanActivate()) {
      cooldownTimer = abilityCooldown;
      activated = true;
      boltFirer.TemporarilyChangeBoltCooldown(newBoltCooldown, abilityDuration);
    }
  }

  override public float GetCooldown() {
    return activated ? cooldownTimer : -1;
  }

  override public bool CanActivate() {
    return !activated;
  }

  public override void ResetCooldown() {
    cooldownTimer = 0;
    activated = false;
  }

  private void Update() {
    cooldownTimer -= Time.deltaTime;
    if (activated & (cooldownTimer < 0)) {
      activated = false;
    }
  }
}
