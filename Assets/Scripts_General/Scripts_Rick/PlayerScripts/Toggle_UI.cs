using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_UI : MonoBehaviour
{   

    public string Toggle_Button = "f5";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(Toggle_Button)){
           Toggle();
       } 
    }

    void Toggle(){
        foreach(Transform child in gameObject.transform){
            if(child.gameObject.activeSelf){
                child.gameObject.SetActive(false);
            }
            else{
                child.gameObject.SetActive(true);
            }
        }
    }

}
