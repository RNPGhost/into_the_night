using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour {
  public abstract string GetName();
  public abstract void Activate();
  public abstract float GetCooldown();
  public abstract bool CanActivate();
}
