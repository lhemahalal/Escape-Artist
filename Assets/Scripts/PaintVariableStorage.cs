using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintVariableStorage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

/*
public class PaintVariableStorage : VariableStorageBehaviour, VariableStorage, IEnumerable<KeyValuePair<string, Value>>, IEnumerable
{
    void Update()
    {
        
        // 'storage' is an InMemoryVariableStorage    
        foreach (var variable in storage)
        {
            string name = variable.Key;
            Yarn.Value value = variable.Value;
        }
        
    }   
}*/
