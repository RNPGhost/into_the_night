using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDirectionMover : MonoBehaviour {

  [SerializeField]
  private Vector3 defaultVelocity;

  private Rigidbody rigidbody;

  private void Start() {
    rigidbody = GetComponent<Rigidbody>();
    SetVelocity(defaultVelocity);
  }

  void SetVelocity (Vector3 velocity) {
    rigidbody.velocity = velocity;
    rigidbody.rotation = Quaternion.LookRotation(velocity);
	}
}
