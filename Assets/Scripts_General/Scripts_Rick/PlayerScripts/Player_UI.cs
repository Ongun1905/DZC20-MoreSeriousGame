using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_UI : MonoBehaviour
{

    public GameObject PlayerCam;

    public RectTransform Selector;
    public Transform Hotbar;
    public Transform Label;

    public Transform PlayerPlaced;
    public LayerMask PlayerItemLayer;
    public float PlaceRange = 5f;

    int imageSpacing = 80;
    public int imageAmount = 9;
    int ImageBoundairy;

    GameObject PlacedItem;
    Transform hit;
    Transform PowerObject;
    Vector3 lastRawHit;


    // Start is called before the first frame update
    void Start()
    {
        ImageBoundairy = ((imageAmount - 1 ) / 2) * imageSpacing;
        changeText(getSelectedItemNumber());
    }

    // Update is called once per frame
    void Update()
    {
        moveSelector(Input.GetAxis("Mouse ScrollWheel"));

        if(Input.GetButtonDown("Fire1")){
            hit = castForwardTargetted();
            if(hit != null){
                hit.GetComponent<PowerInteract>().Interact("LMB");
            }
        }

        if(Input.GetButtonDown("Fire2")){
            hit = castForwardTargetted();
            if(hit != null){
                hit.GetComponent<PowerInteract>().Interact("RMB");
            }
            else{
                hit = castForward();
                if(hit != null){
                    if(CastOnGround(hit)){
                        PlacedItem = Instantiate(getSelectedPrefab(getSelectedItemNumber()), Round(lastRawHit), new Quaternion(0f,0f,0f,0f), PlayerPlaced);
                        PlacedItem.GetComponent<PowerInteract>().PlayerPlaced = true;
                    }
                }
            }
        }
    }       

    void moveSelector(float direction){

        if(direction < 0){
            if(Selector.anchoredPosition.x < ImageBoundairy){
                Selector.anchoredPosition = new Vector3(Selector.anchoredPosition.x + imageSpacing, Selector.anchoredPosition.y, 0);
            }
            else{
                Selector.anchoredPosition = new Vector3(-ImageBoundairy, Selector.anchoredPosition.y, 0);
            }
            changeText(getSelectedItemNumber());
        }
        
        else if(direction > 0){
            if(Selector.anchoredPosition.x > -ImageBoundairy){
                Selector.anchoredPosition = new Vector3(Selector.anchoredPosition.x - imageSpacing, Selector.anchoredPosition.y, 0);
            }
            else{
                Selector.anchoredPosition = new Vector3(ImageBoundairy, Selector.anchoredPosition.y, 0);
            }
            changeText(getSelectedItemNumber());
        }

    }

    float getSelectedItemNumber(){
        return (Selector.anchoredPosition.x + ImageBoundairy) / imageSpacing;
    }

    GameObject getSelectedPrefab(float ItemNumber){

        HotbarItem item;

        foreach(Transform child in Hotbar.transform){
            item = child.GetComponent<HotbarItem>();
            if(item != null){
                if(item.FrameNumber == ItemNumber){
                    return item.ItemPrefab;
                }
            }
        }

        return null;
    }

    void changeText(float selectedFrame){

        HotbarItem item;
        TextMeshProUGUI LabelText;

        foreach(Transform child in Hotbar.transform){
            item = child.GetComponent<HotbarItem>();
            if(item != null){
                if(item.FrameNumber == selectedFrame){
                    LabelText = Label.GetComponent<TextMeshProUGUI>();
                    LabelText.text = item.ItemPrefab.name;
                    return;
                }
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

    Vector3 Round(Vector3 hit){

        return new Vector3(Mathf.Round(hit.x), Mathf.Round(hit.y), Mathf.Round(hit.z));

    }

}
