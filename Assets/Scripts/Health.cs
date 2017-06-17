using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

  [SerializeField]
  private float maxHealth;
  [SerializeField]
  private GameObject deathVFX;
  [SerializeField]
  protected ScoreController scoreController;
  [SerializeField]
  private float scoreValue;

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
	
	private void Die() {
    PlayDeathFX();
    AddToScore();
    DestorySelf();
	}

  private void PlayDeathFX() {
    Instantiate(deathVFX, transform.position, transform.rotation);
  }

  private void AddToScore() {
    scoreController.AddToScore(scoreValue);
  }

  virtual protected void DestorySelf() {
    Destroy(gameObject);
  }
}
