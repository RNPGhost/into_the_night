using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumericalValueUIController : MonoBehaviour {

  [SerializeField]
  private Text textUI;
  [SerializeField]
  private string prefixText;

  public void UpdateValueText(float value) {
    textUI.text = prefixText + value;
  }
}
