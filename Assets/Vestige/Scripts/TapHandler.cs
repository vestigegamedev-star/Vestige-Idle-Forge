using UnityEngine; using UnityEngine.UI;
public class TapHandler : MonoBehaviour {
  public Button tapButton; public Text crystalText; public UpgradeManager upgrades;
  void Start(){ tapButton.onClick.AddListener(()=> IdleSystem.I.Tap()); upgrades.ApplyAll(); InvokeRepeating(nameof(RefreshUI),0.1f,0.1f); }
  void RefreshUI(){ crystalText.text = System.Math.Floor(IdleSystem.I.crystals).ToString(); }
}
