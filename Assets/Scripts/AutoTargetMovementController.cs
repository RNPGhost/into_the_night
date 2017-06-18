using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTargetMovementController : SingleDirectionMover {
  
  [SerializeField]
  private float updateDelay;

  private float updateTimer;
  private GameObject target;
  private float speed;

  private void Start() {
    updateTimer = updateDelay;
  }

  public void SetSpeed(float newSpeed) {
    speed = newSpeed;
  }

  public void SetTarget(GameObject newTarget) {
    target = newTarget;
  }

  private void Update() {
    updateTimer -= Time.deltaTime;
    if (updateTimer < 0) {
      SetVelocity(speed * (target.transform.position - transform.position).normalized);
      updateTimer = updateDelay;
    }
  }
}
