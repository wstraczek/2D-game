using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour{

    private float speed = 10f;
    public Rigidbody2D myRigidbody;

    void Start(){
        
    }

    void FixedUpdate(){
        myRigidbody.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.tag == "Enemy"){
            Destroy(coll.gameObject);
        }
        Destroy(gameObject);
    }
}
