using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int loadSceneIndex;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadSceneIndex);
        }
        
    }
}
