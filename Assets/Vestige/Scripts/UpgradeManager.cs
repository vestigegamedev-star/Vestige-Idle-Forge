using UnityEngine;
[System.Serializable] public class UpgradeDef {
  public string id, name; public int level;
  public double base_cost, cost_mul=1.15, effect_per_level, ticks_per_sec, yield_per_tick, multiplier_per_level=1.0;
}
public class UpgradeManager : MonoBehaviour {
  public UpgradeDef[] defs;
  public double GetCost(UpgradeDef u)=> u.base_cost * System.Math.Pow(u.cost_mul, u.level);
  public void Buy(string id){ var u=Find(id); var cost=GetCost(u); if(!IdleSystem.I.TrySpend(cost)) return; u.level++; Apply(u); }
  public void ApplyAll(){ foreach(var u in defs) Apply(u); }
  void Apply(UpgradeDef u){
    if(u.id=="tap_power") IdleSystem.I.tapValue = 1 + u.level * u.effect_per_level;
    if(u.id=="auto_miner"){ var baseRate=u.ticks_per_sec*u.yield_per_tick; IdleSystem.I.autoPerSec = baseRate * u.level; }
    if(u.id=="yield_boost"){ var mul=System.Math.Pow(u.multiplier_per_level, u.level); IdleSystem.I.tapValue*=mul; IdleSystem.I.autoPerSec*=mul; }
  }
  UpgradeDef Find(string id){ foreach(var d in defs) if(d.id==id) return d; Debug.LogError("Upgrade not found: "+id); return new UpgradeDef{ id=id }; }
}
