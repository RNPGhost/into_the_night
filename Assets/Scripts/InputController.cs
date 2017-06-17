using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

  [SerializeField]
  private TargetBasedMovementController playerMovement;
  [SerializeField]
  private BoltFirer playerBoltFirer;
  [SerializeField]
  private Rigidbody playerRigidbody;
  [SerializeField]
  private Camera mainCamera;

  private void Update () {

    List<Touch> touches = new List<Touch>(Input.touches);

    // Add pc support
    if (Input.GetButton("Fire1")) {
      Touch touch = new Touch() {
        position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
      };
      if (Input.GetButtonDown("Fire1")) {
        touch.phase = TouchPhase.Began;
      }

      touches.Add(touch);
    } else if (Input.GetButtonUp("Fire1")) {
      Touch touch = new Touch() {
        position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
      };
      touch.phase = TouchPhase.Ended;

      touches.Add(touch);
    }
    
    if (touches.Count > 0) {
      // Only control player position with the closest touch
      Touch closestTouchToPlayer = GetClosestTouch(touches, playerRigidbody.position);
      UpdatePlayerMovement(closestTouchToPlayer);
      UpdatePlayerFire(closestTouchToPlayer);
    }
  }

  private Touch GetClosestTouch(List<Touch> touches, Vector3 position) {
    // Returns a new Touch if the touches array is empty
    Touch closestTouch = new Touch();
    float bestDistance = -1;
    foreach (Touch touch in touches) {
      Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
      float distance = Vector3.Distance(position, touchPosition);
      if (bestDistance == -1 || distance < bestDistance) {
        bestDistance = distance;
        closestTouch = touch;
      }
    }
    return closestTouch;
  }

  private void UpdatePlayerMovement(Touch touch) {
    Vector3 closestTouchToPlayerWorldPosition = mainCamera.ScreenToWorldPoint(touch.position);
    playerMovement.SetTargetPosition(new Vector3(closestTouchToPlayerWorldPosition.x, playerRigidbody.position.y, playerRigidbody.position.z));
  }

  private void UpdatePlayerFire(Touch closestTouchToPlayer) {
    if (closestTouchToPlayer.phase == TouchPhase.Began) {
      playerBoltFirer.StartFiring();
    } else if (closestTouchToPlayer.phase == TouchPhase.Ended || closestTouchToPlayer.phase == TouchPhase.Canceled) {
      playerBoltFirer.StopFiring();
    }
  }
}
