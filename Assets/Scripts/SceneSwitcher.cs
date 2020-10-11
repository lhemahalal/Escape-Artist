using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity; 

public class SceneSwitcher : MonoBehaviour
{

    public int scene;
    private bool winState = false;
    InMemoryVariableStorage varStore;
    
    void Start()
    {
        varStore = GameObject.Find("Dialogue Runner").GetComponent<InMemoryVariableStorage>(); 
    }

    void Update()
    {
        if (winState == true)
        {
            winState = false;
            SceneSwitch();
        }

        if (varStore.GetValue("$paintingTime").AsBool)
        {
            varStore.ResetToDefaults(); 
            SceneSwitch();
        }
        if (varStore.GetValue("$donePainting").AsBool)
        {
            varStore.ResetToDefaults(); 
            SceneSwitch();
        }
    }

    public void setWinState(bool set)
    {
        winState = set;
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log("player crossed");
        // //if (other.gameObject.tag == "player")
        // SceneSwitch();
    }
    

    public void SceneSwitch()
    {

        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
