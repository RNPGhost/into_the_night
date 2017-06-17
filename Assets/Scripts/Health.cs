using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

  [SerializeField]
  private float maxHealth;

  private float health;

  public float CurrentHealth {
    get {
      return health;
    }
  }

  private void Start() {
    health = maxHealth;
  }

  public void TakeDamage(float damage) {
    health = Mathf.Max(health - damage, 0.0f);
    if (health == 0) {
      Die();
    }
  }
	
	virtual protected void Die() {
    Destroy(gameObject);
	}
}
