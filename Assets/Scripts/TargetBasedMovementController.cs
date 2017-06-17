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

  private Rigidbody playerRigidbody;
  private Vector3 targetPosition;
  

  public void SetTargetPosition(Vector3 newTargetPosition) {
    targetPosition = newTargetPosition;
  }

  private void Start() {
    playerRigidbody = GetComponent<Rigidbody>();
    targetPosition = playerRigidbody.position;
  }

  private void FixedUpdate () {
    MoveTowardsTargetPosition();
	}

  private void MoveTowardsTargetPosition() {
    // Check proximity to target to prevent 0 rounding errors
    if (Vector3.Distance(targetPosition, playerRigidbody.position) < smallDistance) {
      playerRigidbody.velocity = Vector3.zero;
      playerRigidbody.position = targetPosition;
    } else {
      playerRigidbody.velocity = speed * (targetPosition - playerRigidbody.position).normalized;
    }

    if (tiltSideways) {
      playerRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, -tilt * playerRigidbody.velocity.x);
    }
  }
}
