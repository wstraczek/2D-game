using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform childTranfsorm;
    [SerializeField]
    private Transform trandformB;

    // Start is called before the first frame update
    void Start(){
        posA = childTranfsorm.localPosition;
        posB = trandformB.localPosition;
        nextPos = posB;
    }

    // Update is called once per frame
    void Update(){
        Move();
    }

    private void Move(){
        childTranfsorm.localPosition = Vector3.MoveTowards(childTranfsorm.localPosition,nextPos,speed*Time.deltaTime);
        if (Vector3.Distance(childTranfsorm.localPosition,nextPos)<= 0.1){
            changePos();
        }
    }

    private void changePos(){
        nextPos = nextPos != posA ? posA : posB;
    }
}
