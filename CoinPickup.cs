using UnityEngine;

public class CoinPickup : MonoBehaviour {
    void Update(){ transform.Rotate(0,120f*Time.deltaTime,0); }
    void OnTriggerEnter(Collider c){
        if(c.CompareTag("Player")){
            RunawayTrainGame.I.AddCoin();
            Destroy(gameObject);
        }
    }
}