using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressWaypoints : MonoBehaviour
{
    public int WPNumber;
    public int CarTracking = 0;

    public int Position = 0;

    public int Lap1Position=0;
    public int Lap2Position=0;
    public int Lap3Position=0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ProgressPlayer1"))
        {
            CarTracking = other.GetComponent<ProgressTracker>().CurrentWP;

            if (CarTracking < WPNumber)
            {
                other.GetComponent<ProgressTracker>().CurrentWP = WPNumber;

                /*if(SaveScript.LapNumber == 1)
                {
                    Lap1Position++;
                    SaveScript.Player1Position = Lap1Position;
                   
                }
                if (SaveScript.LapNumber == 2)
                {
                    Lap2Position++;
                    SaveScript.Player1Position = Lap2Position;

                }
                if (SaveScript.LapNumber == 3)
                {
                    Lap3Position++;
                    SaveScript.Player1Position = Lap3Position;

                }
            }

            if(CarTracking>WPNumber){
                other.GetComponent<ProgressTracker>().LastWPNumber=WPNumber;
            }*/
            }

            if (other.gameObject.CompareTag("ProgressPlayer2"))
            {

                /*if (SaveScript.Player2LapNumber == 1){
                    Lap1Position++;

                }
                if (SaveScript.Player2LapNumber == 2)
                {
                    Lap2Position++;

                }
                if (SaveScript.Player2LapNumber == 3)
                {
                    Lap3Position++;

                }*/
            }
        }

        void Start()
        {
            WPNumber = System.Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(gameObject.name, "[^0-9]", ""));
        }

    }
}
