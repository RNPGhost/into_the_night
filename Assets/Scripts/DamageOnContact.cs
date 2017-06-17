using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour {

  [SerializeField]
  private float damage;
  
  private void OnTriggerEnter(Collider other) {
    Health health = other.GetComponent<Health>();
    if (health != null) {
      health.TakeDamage(damage);
    }
  }
}
