using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticlesWhenDone : MonoBehaviour {

  private ParticleSystem particleSystem;

  private void Update() {
    if (particleSystem) {
      if (!particleSystem.IsAlive()) {
        Destroy(gameObject);
      }
    }
  }

  private void Start() {
    particleSystem = GetComponent<ParticleSystem>();
  }
}
