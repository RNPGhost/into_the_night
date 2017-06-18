using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

  [SerializeField]
  private float rotationSpeed;

  void Start () {
    GetComponent<Rigidbody>().angularVelocity = rotationSpeed * Random.insideUnitSphere;
  }
}
