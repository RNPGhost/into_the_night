using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

  [SerializeField]
  private TargetBasedMovementController playerMovement;
  [SerializeField]
  private Rigidbody playerRigidbody;
  
	private void Update () {
    float horizontalInput = Input.GetAxisRaw("Horizontal");
    if (horizontalInput != 0) {
      playerMovement.SetTargetPosition(new Vector3(5 * horizontalInput, playerRigidbody.position.y, playerRigidbody.position.z));
    }
  }
}
