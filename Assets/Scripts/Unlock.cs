using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    bool hasKey = false; 
    SceneSwitcher sw; 

    // Start is called before the first frame update
    void Start()
    {
        sw = GetComponent<SceneSwitcher>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (hasKey)
            {
                Cursor.visible = true;
                sw.setWinState(true); 
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "key")
        {
            hasKey = true; 
        }
    }
    
    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "key")
        {
            hasKey = true; 
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "key")
        {
            hasKey = false; 
        }
    }
}
