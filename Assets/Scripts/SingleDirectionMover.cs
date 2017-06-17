using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDirectionMover : MonoBehaviour {

  [SerializeField]
  private Vector3 defaultVelocity;

  private Rigidbody objectRigidbody;

  private void Start() {
    objectRigidbody = GetComponent<Rigidbody>();
    SetVelocity(defaultVelocity);
  }

  void SetVelocity (Vector3 velocity) {
    objectRigidbody.velocity = velocity;
    objectRigidbody.rotation = Quaternion.LookRotation(velocity);
	}
}
