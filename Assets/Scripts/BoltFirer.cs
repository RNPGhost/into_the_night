using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltFirer : MonoBehaviour {

  [SerializeField]
  private GameObject boltPrefab;
  [SerializeField]
  private Transform boltSpawn;
  [SerializeField]
  private bool fireOnStart;
  [SerializeField]
  private float boltCooldown;
  [SerializeField]
  private float boltSpeed;
  [SerializeField]
  private AudioSource boltSFX;

  private float defaultBoltCooldown;
  private float boltTimer;
  private bool boltCooldownChanged;
  private float changedBoltCooldownTimer;
  private bool fire;

  public void StartFiring() {
    fire = true;
  }

  public void StopFiring() {
    fire = false;
  }

  public void TemporarilyChangeBoltCooldown(float newBoltCooldown, float changeDuration) {
    changedBoltCooldownTimer = changeDuration;
    boltCooldown = newBoltCooldown;
    boltCooldownChanged = true;
  }

  private void Start() {
    boltTimer = 0;
    defaultBoltCooldown = boltCooldown;
    boltCooldownChanged = false;
    fire = fireOnStart;
  }

  private void Update () {
    if (boltCooldownChanged) {
      changedBoltCooldownTimer -= Time.deltaTime;
      if (changedBoltCooldownTimer <= 0) {
        boltCooldown = defaultBoltCooldown;
        boltCooldownChanged = false;
      }
    }

    boltTimer -= Time.deltaTime;
    if (fire && (boltTimer <= 0)) {
      GameObject bolt = Instantiate(boltPrefab, boltSpawn.position, boltSpawn.rotation) as GameObject;
      bolt.GetComponent<SingleDirectionMover>().SetVelocity(boltSpeed * (boltSpawn.rotation * Vector3.forward).normalized);
      boltSFX.Play();
      boltTimer = boltCooldown;
    }
  }
}
