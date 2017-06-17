using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnContact : MonoBehaviour {

  private void OnTriggerEnter(Collider other) {
    // This is fine if there is only 1 thing we want to avoid colliding with.
    // If more special cases become necessary, this should be pulled out to a Utils class.
    if (other.tag == "Boundary") {
      return;
    }
    Destroy(gameObject);
  }
}
