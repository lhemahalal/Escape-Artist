using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 

public class Destroy : MonoBehaviour
{
    InMemoryVariableStorage varStore;

    // Start is called before the first frame update
    void Start()
    {
        varStore = GameObject.Find("Dialogue Runner").GetComponent<InMemoryVariableStorage>(); 

    }

    // Update is called once per frame
    void Update()
    {
        if (varStore.GetValue("$hasLight").AsBool)
        {
            Destroy(gameObject); 
        }
    }
}
