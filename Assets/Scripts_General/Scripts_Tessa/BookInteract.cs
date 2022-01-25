using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteract : MonoBehaviour
{

    public enum InterAction{
        Destroy,
        Rotate,
        TogglePowerCube,
        ToggleInformation,
        Button
    };

    public bool PlayerPlaced = false;

    public InterAction Action_LMB;
    public InterAction Action_RMB;

    string Action = "None";

    PowerCube PowerCube;
    Transform Information;

    public bool ButtonPressed;

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
        else if(Action.Equals("ToggleInformation")){
            Information = transform.Find("Information");
            if(Information.gameObject.activeSelf){
                Information.gameObject.SetActive(false);
            }
            else{
                Information.gameObject.SetActive(true);
            }
        }
        else if(Action.Equals("Button")){
            ButtonPressed = true;
        }

    }

}
