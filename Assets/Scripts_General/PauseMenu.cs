using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject[] Disable_This_UI;
    public GameObject Buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            TogglePause();
        }

        if(Buttons.activeSelf){
            if(Input.GetKeyDown("1")){
                LoadLevel_1();
            }
            if(Input.GetKeyDown("2")){
                LoadLevel_2();
            }
            if(Input.GetKeyDown("3")){
                LoadLevel_3();
            }
        }

    }
    

    void TogglePause(){
        foreach(Transform child in gameObject.transform){
            if(child.gameObject.activeSelf){
                foreach(GameObject kiddo in Disable_This_UI){
                    kiddo.SetActive(true);
                }
                child.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else{
                foreach(GameObject kiddo in Disable_This_UI){
                    kiddo.SetActive(false);
                }
                child.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void LoadLevel_1(){
        SceneManager.LoadScene(3);
    }

    public void LoadLevel_2(){
        SceneManager.LoadScene(5);
    }

    public void LoadLevel_3(){
        SceneManager.LoadScene(7);
    }

    public void CloseGame(){
        Application.Quit();
    }
    

}
