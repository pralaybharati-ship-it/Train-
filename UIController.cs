using UnityEngine;
using UnityEngine.UI;

public static class UIController {
    static Canvas canvas; static Text title,stats,gameOver;

    public static void Build(){
        var c=new GameObject("HUD").AddComponent<Canvas>();
        c.renderMode=RenderMode.ScreenSpaceOverlay;
        c.gameObject.AddComponent<CanvasScaler>().uiScaleMode=CanvasScaler.ScaleMode.ScaleWithScreenSize;
        c.gameObject.GetComponent<CanvasScaler>().referenceResolution=new Vector2(1080,1920);
        canvas=c;
        title=Text("RUNAWAY TRAIN",40,new Vector2(0,-70),TextAnchor.UpperCenter);
        stats=Text("",30,new Vector2(30,-30),TextAnchor.UpperLeft);
        gameOver=Text("",55,new Vector2(0,0),TextAnchor.MiddleCenter);
        gameOver.gameObject.SetActive(false);
    }

    static Text Text(string s,int size,Vector2 pos,TextAnchor anchor){
        var g=new GameObject(s);g.transform.SetParent(canvas.transform,false);
        var t=g.AddComponent<Text>();t.text=s;t.font=Resources.GetBuiltinResource<Font>("Arial.ttf");
        t.fontSize=size;t.alignment=anchor;t.color=Color.white;
        var r=t.rectTransform;r.anchorMin=r.anchorMax=new Vector2(.5f,1);
        r.anchoredPosition=pos;r.sizeDelta=new Vector2(1000,180);return t;
    }

    public static void ShowIntro(){ Refresh(); }
    public static void Refresh(){
        if(stats!=null&&RunawayTrainGame.I!=null)
            stats.text=$"COINS  {RunawayTrainGame.I.Coins}\\nSCORE  {RunawayTrainGame.I.Score}\\nHP  {RunawayTrainGame.I.Player.Health}";
    }
    public static void GameOver(int score,int coins){
        if(gameOver==null)return;
        gameOver.gameObject.SetActive(true);
        gameOver.text=$"GAME OVER\\n\\nSCORE {score}\\nCOINS {coins}\\n\\nPress R to restart";
        var helper=canvas.gameObject.AddComponent<RestartHelper>();
    }
}

public class RestartHelper:MonoBehaviour{
    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            Time.timeScale=1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}