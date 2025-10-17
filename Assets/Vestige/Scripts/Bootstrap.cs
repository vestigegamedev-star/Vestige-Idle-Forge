using UnityEngine; using UnityEngine.UI; using UnityEngine.EventSystems;
public class Bootstrap {
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
  static void Init(){
    var host=new GameObject("VestigeHost"); host.AddComponent<IdleSystem>();
    var um=host.AddComponent<UpgradeManager>();
    um.defs=new UpgradeDef[]{
      new UpgradeDef{ id="tap_power", name="Tap Power", base_cost=10, cost_mul=1.15, effect_per_level=1 },
      new UpgradeDef{ id="auto_miner", name="Auto Miner", base_cost=50, cost_mul=1.20, ticks_per_sec=0.2, yield_per_tick=1 },
      new UpgradeDef{ id="yield_boost", name="Yield Boost", base_cost=200, cost_mul=1.25, multiplier_per_level=1.10 }
    };
    var canvasGO=new GameObject("Canvas",typeof(Canvas),typeof(CanvasScaler),typeof(GraphicRaycaster));
    var c=canvasGO.GetComponent<Canvas>(); c.renderMode=RenderMode.ScreenSpaceOverlay;
    var sc=canvasGO.GetComponent<CanvasScaler>(); sc.uiScaleMode=CanvasScaler.ScaleMode.ScaleWithScreenSize; sc.referenceResolution=new Vector2(1080,1920);
    new GameObject("EventSystem",typeof(EventSystem),typeof(StandaloneInputModule));
    var textGO=new GameObject("CrystalText",typeof(Text)); textGO.transform.SetParent(canvasGO.transform,false);
    var txt=textGO.GetComponent<Text>(); txt.font=Resources.GetBuiltinResource<Font>("Arial.ttf"); txt.fontSize=64; txt.alignment=TextAnchor.UpperCenter; txt.text="0";
    var rtT=textGO.GetComponent<RectTransform>(); rtT.anchorMin=new Vector2(0.1f,0.8f); rtT.anchorMax=new Vector2(0.9f,0.9f); rtT.offsetMin=rtT.offsetMax=Vector2.zero;
    var btnGO=new GameObject("TapButton",typeof(Image),typeof(Button)); btnGO.transform.SetParent(canvasGO.transform,false);
    btnGO.GetComponent<Image>().color=new Color(0.2f,0.6f,1f,0.8f);
    var rtB=btnGO.GetComponent<RectTransform>(); rtB.anchorMin=new Vector2(0.2f,0.2f); rtB.anchorMax=new Vector2(0.8f,0.5f); rtB.offsetMin=rtB.offsetMax=Vector2.zero;
    var th=host.AddComponent<TapHandler>(); th.tapButton=btnGO.GetComponent<Button>(); th.crystalText=txt; th.upgrades=um;
  }
}
