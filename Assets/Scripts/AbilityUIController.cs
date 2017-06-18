using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUIController : MonoBehaviour {

  [SerializeField]
  private Button abilityButton;
  [SerializeField]
  private Text abilityButtonText;
  [SerializeField]
  private AbilityController abilityController;

  private Ability ability;

  private void Start() {
    ability = abilityController.CurrentAbility;
  }

  private void Update () {
    UpdateEnabled();
    UpdateText();
  }

  private void UpdateEnabled() {
    abilityButton.interactable = ability.CanActivate();
  }

  private void UpdateText() {
    if (ability.CanActivate()) {
      abilityButtonText.text = "Activate\n" + ability.GetName();
    } else {
      abilityButtonText.text = ((int) ability.GetCooldown()).ToString();
    }
  }
}
