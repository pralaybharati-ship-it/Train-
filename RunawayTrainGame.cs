using UnityEngine;
using UnityEngine.SceneManagement;

public class RunawayTrainGame : MonoBehaviour {
    public static RunawayTrainGame I { get; private set; }
    public PlayerRunner Player { get; private set; }
    public int Coins { get; private set; }
    public int Score { get; private set; }
    public bool Playing { get; private set; }

    float scoreTimer;
    Transform worldRoot;

    void Awake() {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
    }

    void Start() {
        CreateWorld();
        CreatePlayer();
        Playing = true;
        UIController.Build();
        UIController.ShowIntro();
    }

    void Update() {
        if (!Playing) return;
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= .25f) {
            Score += 1;
            scoreTimer = 0;
            UIController.Refresh();
        }
    }

    void CreateWorld() {
        worldRoot = new GameObject("TRAIN_WORLD").transform;
        Material railMat = Mat(new Color(.08f,.08f,.09f));
        Material wood = Mat(new Color(.22f,.10f,.045f));
        Material metal = Mat(new Color(.25f,.28f,.32f));
        Material red = Mat(new Color(.65f,.05f,.03f));

        for (int i=0;i<70;i++) {
            float z=i*6f;
            Cube("Roof_"+i,new Vector3(0,2.0f,z),new Vector3(8f,.25f,6f),metal,worldRoot);
            Cube("LeftRail_"+i,new Vector3(-3.5f,2.55f,z),new Vector3(.15f,1f,6f),railMat,worldRoot);
            Cube("RightRail_"+i,new Vector3(3.5f,2.55f,z),new Vector3(.15f,1f,6f),railMat,worldRoot);
            if(i%3==0) {
                Cube("Vent_"+i,new Vector3(0,2.55f,z),new Vector3(1.5f,.65f,1f),wood,worldRoot);
            }
            if(i%8==0) {
                var o=Cube("Obstacle_"+i,new Vector3(i%2==0?-1.6f:1.6f,3.0f,z+2.2f),new Vector3(1.8f,1.6f,1.2f),red,worldRoot);
                o.tag="Obstacle";
            }
            if(i%5==0) {
                var c=GameObject.CreatePrimitive(PrimitiveType.Sphere);
                c.name="Coin_"+i; c.transform.position=new Vector3(i%2==0?1.8f:-1.8f,3.3f,z+3f);
                c.transform.localScale=Vector3.one*.45f;
                c.GetComponent<Renderer>().material=Mat(Color.yellow);
                var col=c.GetComponent<Collider>(); col.isTrigger=true;
                c.AddComponent<CoinPickup>();
            }
        }
    }

    void CreatePlayer() {
        var go=GameObject.CreatePrimitive(PrimitiveType.Capsule);
        go.name="PLAYER";
        go.tag="Player";
        go.transform.position=new Vector3(0,3.2f,4);
        go.transform.localScale=new Vector3(.75f,1f,.75f);
        go.GetComponent<Renderer>().material=Mat(new Color(.04f,.18f,.8f));
        var rb=go.AddComponent<Rigidbody>();
        rb.constraints=RigidbodyConstraints.FreezeRotation;
        Player=go.AddComponent<PlayerRunner>();
        Camera.main.transform.position=new Vector3(0,6,-7);
        Camera.main.transform.rotation=Quaternion.Euler(15,0,0);
        var cam=Camera.main.gameObject.AddComponent<FollowCamera>();
        cam.target=go.transform;
    }

    public void AddCoin() { Coins++; UIController.Refresh(); Save(); }
    public void AddScore(int n) { Score+=n; UIController.Refresh(); }
    public void Save() {
        if(SaveManager.I==null)return;
        SaveManager.I.Data.coins=Coins;
        SaveManager.I.Data.score=Score;
        SaveManager.I.Data.health=Player?Player.Health:100;
        SaveManager.I.Data.hasPlayed=true;
        SaveManager.I.Save();
    }
    public void GameOver() {
        Playing=false; Save(); UIController.GameOver(Score,Coins);
        Time.timeScale=0;
    }
    public void Restart() {
        Time.timeScale=1;
        if(SaveManager.I!=null) SaveManager.I.NewGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    GameObject Cube(string n,Vector3 p,Vector3 s,Material m,Transform parent) {
        var g=GameObject.CreatePrimitive(PrimitiveType.Cube);
        g.name=n; g.transform.SetParent(parent); g.transform.position=p; g.transform.localScale=s;
        g.GetComponent<Renderer>().material=m; return g;
    }
    Material Mat(Color c) { var m=new Material(Shader.Find("Standard")); m.color=c; return m; }
}