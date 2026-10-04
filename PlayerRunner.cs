using UnityEngine;

public class PlayerRunner : MonoBehaviour {
    public int Health { get; private set; } = 100;
    Rigidbody rb;
    float laneX;
    float speed=7f;
    bool grounded;

    void Awake(){ rb=GetComponent<Rigidbody>(); }

    void Update() {
        float h=Input.GetAxisRaw("Horizontal");
        if(Mathf.Abs(h)<.1f) {
            if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)) h=-1;
            if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)) h=1;
        }
        laneX=Mathf.Clamp(laneX+h*4f*Time.deltaTime,-2.6f,2.6f);
        if((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))&&grounded)
            rb.AddForce(Vector3.up*7.5f,ForceMode.VelocityChange);
    }

    void FixedUpdate() {
        Vector3 p=rb.position;
        p.x=Mathf.Lerp(p.x,laneX,.25f);
        p.z += speed*Time.fixedDeltaTime;
        rb.MovePosition(p);
        grounded=Mathf.Abs(rb.velocity.y)<.15f && p.y<3.3f;
    }

    void OnCollisionEnter(Collision c) {
        if(c.gameObject.CompareTag("Obstacle")) {
            Health-=25;
            c.gameObject.SetActive(false);
            RunawayTrainGame.I.Save();
            UIController.Refresh();
            if(Health<=0) RunawayTrainGame.I.GameOver();
        }
    }
}