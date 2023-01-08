using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorHalfwaypoints : MonoBehaviour
{
    public GameObject FinishPoint;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ProgressPlayer1"))
        {
            SaveScript.HalfWayActivated = true;

            if(SaveScript.LapNumber==SaveScript.MaxLaps){
                FinishPoint.SetActive(true);
            }
        }
    }
}
