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
    public LayerMask PlayerPlacesOn;
    public LayerMask PlayerPlacedLayer;

    int imageSpacing = 80;
    int imageAmount = 7;
    int ImageBoundairy;

    GameObject SelectedItem;


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
            castForward();
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

    RaycastHit castForward(){
        
        RaycastHit hit;
        Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit);
        Debug.Log(hit.transform.name);
        return hit;

    }
}
