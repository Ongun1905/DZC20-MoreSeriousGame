using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_UI_Time : MonoBehaviour
{

    public GameObject PlayerCam;

    public Transform PlayerPlaced;
    public LayerMask PlayerItemLayer;
    public float PlaceRange = 5f;

    GameObject PlacedItem;
    Transform hit;
    Transform PowerObject;
    Vector3 lastRawHit;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire1")){
            hit = castForwardTargetted();
            if(hit != null){
                hit.GetComponent<BookInteract>().Interact("LMB");
            }
        }

        if(Input.GetButtonDown("Fire2")){
            hit = castForwardTargetted();
            if(hit != null){
                hit.GetComponent<BookInteract>().Interact("RMB");
            }
        }
    }       

    Transform castForward(){
        
        RaycastHit hit;
        if(Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, PlaceRange)){
            lastRawHit = hit.point;
            return hit.transform;
        }
        
        lastRawHit = hit.point;

        return null;

    }

    Transform castForwardTargetted(){
        
        RaycastHit hit;
        if(Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, PlaceRange, PlayerItemLayer)){
            return hit.transform;
        }

        return null;

    }

    bool CastOnGround(Transform hit){

        if (lastRawHit.y == 0){
            return true;
        }

        return false;

    }

}
