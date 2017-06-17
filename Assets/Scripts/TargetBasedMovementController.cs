using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBasedMovementController : MonoBehaviour {

  [SerializeField]
  private float speed;
  [SerializeField]
  private float smallDistance;
  [SerializeField]
  private bool tiltSideways;
  [SerializeField]
  private float tilt;

  private Rigidbody objectRigidbody;
  private Vector3 targetPosition;
  

  public void SetTargetPosition(Vector3 newTargetPosition) {
    targetPosition = newTargetPosition;
  }

  private void Start() {
    objectRigidbody = GetComponent<Rigidbody>();
    targetPosition = objectRigidbody.position;
  }

  private void FixedUpdate() {
    MoveTowardsTargetPosition();
	}

  private void MoveTowardsTargetPosition() {
    // Check proximity to target to prevent 0 rounding errors
    if (Vector3.Distance(targetPosition, objectRigidbody.position) < smallDistance) {
      objectRigidbody.velocity = Vector3.zero;
      objectRigidbody.position = targetPosition;
    } else {
      objectRigidbody.velocity = speed * (targetPosition - objectRigidbody.position).normalized;
    }

    if (tiltSideways) {
      objectRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, -tilt * objectRigidbody.velocity.x);
    }
  }
}
