using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticlesWhenDone : MonoBehaviour {

  private ParticleSystem objectParticleSystem;

  private void Update() {
    if (objectParticleSystem) {
      if (!objectParticleSystem.IsAlive()) {
        Destroy(gameObject);
      }
    }
  }

  private void Start() {
    objectParticleSystem = GetComponent<ParticleSystem>();
  }
}
