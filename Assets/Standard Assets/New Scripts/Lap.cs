using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Player"))
        {
            if(SaveScript.HalfWayActivated==true){
                SaveScript.HalfWayActivated=false;

                SaveScript.LastLapTimeMinutes=SaveScript.LapTimeMinutes;
                SaveScript.LastLapTimeSeconds=SaveScript.LapTimeSeconds;
                SaveScript.LapNumber++;
                SaveScript.LapChange=true;

                if(SaveScript.LapNumber==2){
                    SaveScript.BestLapTimeMinutes=SaveScript.LapTimeMinutes;
                    SaveScript.BestLapTimeSeconds=SaveScript.LapTimeSeconds;
                }

                SaveScript.CheckPointPass1 = false;
                SaveScript.CheckPointPass2 = false;
                SaveScript.CheckPointPass3 = false;
                SaveScript.CheckPointPass4 = false;
                SaveScript.CheckPointPass5 = false;
                SaveScript.CheckPointPass6 = false;
                SaveScript.CheckPointPass7 = false;
                SaveScript.CheckPointPass8 = false;
                SaveScript.CheckPointPass9 = false;
            }
            

            

        }

        if (other.gameObject.CompareTag("Player2"))
        {
            SaveScript.Player2LapNumber++;
        }*/
    }
}
