using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDirectionMover : MonoBehaviour {

  public void SetVelocity (Vector3 velocity) {
    Rigidbody objectRigidbody = GetComponent<Rigidbody>();
    objectRigidbody.velocity = velocity;
    objectRigidbody.rotation = Quaternion.LookRotation(velocity);
  }
}
