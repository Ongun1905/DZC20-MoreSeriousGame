using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInteract : MonoBehaviour
{

    public enum InterAction{
        Destroy,
        Rotate,
        TogglePowerCube
    };

    public bool PlayerPlaced = false;

    public InterAction Action_LMB;
    public InterAction Action_RMB;

    string Action = "None";

    PowerCube PowerCube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(string button){

        if(button.Equals("LMB")){
            Action = Action_LMB.ToString();
        }
        else if(button.Equals("RMB")){
           Action = Action_RMB.ToString(); 
        }

        if(Action.Equals("Destroy") && PlayerPlaced){
            Destroy(gameObject);
        }
        else if(Action.Equals("Rotate") && PlayerPlaced){
            transform.Rotate(0f, 90f, 0f, Space.Self);
        }
        else if(Action.Equals("TogglePowerCube")){
            PowerCube = transform.Find("PowerCube").GetComponent<PowerCube>();
            if(PowerCube.POWERSTATE){ PowerCube.POWERSTATE= false; }
            else{ PowerCube.POWERSTATE = true; }
            PowerCube.UpdateMaterial(PowerCube.POWERSTATE);
        }

    }

}
