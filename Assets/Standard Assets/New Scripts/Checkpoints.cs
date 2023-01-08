using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{

    public bool Checkpoint1 = true;
    public bool Checkpoint2 = false;
    public bool Checkpoint3 = false;
    public bool Checkpoint4 = false;
    public bool Checkpoint5 = false;
    public bool Checkpoint6 = false;
    public bool Checkpoint7 = false;
    public bool Checkpoint8 = false;
    public bool Checkpoint9 = false;
    public bool Checkpoint10 = false;
    public bool Checkpoint11 = false;
    public bool Checkpoint12 = false;
    public bool Checkpoint13 = false;
    public bool Checkpoint14 = false;
    public bool Checkpoint15 = false;
    public bool Checkpoint16 = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(Checkpoint1 == true)
            {
                SaveScript.CheckPointPass1 = true;
            }
            if (Checkpoint2 == true)
            {
                SaveScript.CheckPointPass2 = true;
            }
            if(Checkpoint3 == true)
            {
                SaveScript.CheckPointPass3 = true;
            }
            if (Checkpoint4 == true)
            {
                SaveScript.CheckPointPass4 = true;
            }
            if(Checkpoint5 == true)
            {
                SaveScript.CheckPointPass5 = true;
            }
            if (Checkpoint6 == true)
            {
                SaveScript.CheckPointPass6 = true;
            }
            if(Checkpoint7 == true)
            {
                SaveScript.CheckPointPass7 = true;
            }
            if (Checkpoint8 == true)
            {
                SaveScript.CheckPointPass8 = true;
            }
            if(Checkpoint9 == true)
            {
                SaveScript.CheckPointPass9 = true;
            }
            if (Checkpoint10 == true)
            {
                SaveScript.CheckPointPass10 = true;
            }
            if(Checkpoint11 == true)
            {
                SaveScript.CheckPointPass11 = true;
            }
            if (Checkpoint12 == true)
            {
                SaveScript.CheckPointPass12 = true;
            }
            if(Checkpoint13 == true)
            {
                SaveScript.CheckPointPass13 = true;
            }
            if (Checkpoint14 == true)
            {
                SaveScript.CheckPointPass14 = true;
            }
            if(Checkpoint15 == true)
            {
                SaveScript.CheckPointPass15 = true;
            }
            if (Checkpoint16 == true)
            {
                SaveScript.CheckPointPass16 = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
