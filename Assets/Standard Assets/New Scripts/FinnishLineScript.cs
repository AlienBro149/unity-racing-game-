using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinnishLineScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            SaveScript.RaceOver=true;
            Time.timeScale=0.2f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
