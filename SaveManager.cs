using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveData {
    public int coins;
    public int score;
    public int checkpoint;
    public int health = 100;
    public bool hasPlayed;
}

public class SaveManager : MonoBehaviour {
    public static SaveManager I { get; private set; }
    public SaveData Data { get; private set; }
    string Path => System.IO.Path.Combine(Application.persistentDataPath, "runaway_train_save.json");

    void Awake() {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this; DontDestroyOnLoad(gameObject); Load();
    }

    public void Load() {
        try {
            if (File.Exists(Path)) Data = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path));
            if (Data == null) Data = new SaveData();
        } catch { Data = new SaveData(); }
    }

    public void Save() {
        if (Data == null) Data = new SaveData();
        try {
            string tmp = Path + ".tmp";
            File.WriteAllText(tmp, JsonUtility.ToJson(Data, true));
            if (File.Exists(Path)) File.Delete(Path);
            File.Move(tmp, Path);
        } catch (Exception e) { Debug.LogWarning("Save failed: " + e.Message); }
    }

    public void NewGame() { Data = new SaveData(); Save(); }
    void OnApplicationPause(bool p) { if (p) Save(); }
    void OnApplicationQuit() { Save(); }
}