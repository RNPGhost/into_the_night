using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumericalValueUIController : MonoBehaviour {

  [SerializeField]
  private GUIText textUI;
  [SerializeField]
  private string prefixText;

  public void UpdateValueText(float value) {
    textUI.text = prefixText + value;
  }
}
