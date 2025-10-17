using UnityEngine;
public class IdleSystem : MonoBehaviour {
    public static IdleSystem I;
    public double crystals, tapValue = 1, autoPerSec = 0;
    double lastUpdate;
    void Awake(){ if(I==null){ I=this; DontDestroyOnLoad(gameObject);} else Destroy(gameObject); }
    void Start(){ lastUpdate = Time.realtimeSinceStartupAsDouble; Load(); }
    void Update(){ var now=Time.realtimeSinceStartupAsDouble; var dt=now-lastUpdate; if(dt>0){ crystals += autoPerSec*dt; lastUpdate=now; } }
    public void Tap(){ crystals += tapValue; }
    public bool TrySpend(double amt){ if(crystals<amt) return false; crystals-=amt; return true; }
    public void Save(){ PlayerPrefs.SetString("crystals", crystals.ToString("R")); }
    public void Load(){ if(PlayerPrefs.HasKey("crystals") && double.TryParse(PlayerPrefs.GetString("crystals"), out var v)) crystals=v; }
}
