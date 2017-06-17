using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

  [SerializeField]
  private float maxHealth;
  [SerializeField]
  private GameObject deathVFX;
  
  private float health;

  public float CurrentHealth {
    get {
      return health;
    }
  }

  private void Start() {
    Initialization();
  }

  virtual protected void Initialization() {
    health = maxHealth;
  }

  public void TakeDamage(float damage) {
    health = Mathf.Max(health - damage, 0.0f);
    if (health == 0) {
      Die();
    }
  }
	
	private void Die() {
    PlayDeathFX();
    DestroySelf();
	}

  private void PlayDeathFX() {
    Instantiate(deathVFX, transform.position, transform.rotation);
  }

  virtual protected void DestroySelf() {
    Destroy(gameObject);
  }
}
