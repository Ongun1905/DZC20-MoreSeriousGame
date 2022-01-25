using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenInteract : MonoBehaviour
{
    GameObject c2;

    // Start is called before the first frame update
    void Start()
    {
        c2 = GameObject.Find("ChickenInactive");
        c2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 e = GameObject.Find("LogicPlayer").transform.position;
         float d = Vector3.Distance(transform.position, e);
         if(d < 10f && Input.GetButtonDown("Fire1")){
            GameObject c = GameObject.Find("ChickenActive");
            if(c.gameObject.activeSelf){
                c.gameObject.SetActive(false);
                c2.gameObject.SetActive(true);
            }
         }
    }

}
