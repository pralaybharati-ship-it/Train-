using UnityEngine;

public class FollowCamera : MonoBehaviour {
    public Transform target;
    void LateUpdate(){
        if(!target)return;
        Vector3 desired=target.position+new Vector3(0,4.5f,-7.5f);
        transform.position=Vector3.Lerp(transform.position,desired,8f*Time.deltaTime);
        transform.LookAt(target.position+Vector3.up*1.2f);
    }
}