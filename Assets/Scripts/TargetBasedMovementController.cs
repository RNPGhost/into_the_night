using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBasedMovementController : MonoBehaviour {

  [SerializeField]
  private float speed;

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
    float delta = 0.1f;
    if (Vector3.Distance(targetPosition, playerRigidbody.position) < delta) {
      playerRigidbody.velocity = Vector3.zero;
      playerRigidbody.position = targetPosition;
    } else {
      playerRigidbody.velocity = speed * (targetPosition - playerRigidbody.position).normalized;
    }
  }
}
