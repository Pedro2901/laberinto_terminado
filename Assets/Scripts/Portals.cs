using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    private Transform destination;
        public bool isOrange;
    public float distance =0.2f ;
    // Start is called before the first frame update
    void Start()
    {
        if(isOrange==false){
            destination= GameObject.FindGameObjectWithTag("Portal1-1").GetComponent<Transform>();
        }else{
            destination= GameObject.FindGameObjectWithTag("Portal1-2").GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(Vector2.Distance(transform.position, other.transform.position)>distance){
            other.transform.position=new Vector2(destination.position.x,destination.position.y); 
        }
    }
}
