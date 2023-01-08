using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


    public class UIScript : MonoBehaviour
    {
        public Text LapNumberText;
        public Text TotalLapsText;
        public Text SpeedText;
        public Text PlayerPositionText;
        public Text TotalCarsText;


        public Text LapTimeMinutesText;
        public Text LapTimeSecondsText;

        public Text RaceTimeMinutesText;
        public Text RaceTimeSecondsText;

        public Text LastLapTimeMinutesText;
        public Text LastLapTimeSecondsText;

        public Text BestLapTimeMinutesText;
        public Text BestLapTimeSecondsText;

        
        public int TotalLaps;
        public int TotalCars;


        // Start is called before the first frame update
        void Start()
        {
            SaveScript.MaxLaps=TotalLaps;
            SaveScript.TotalCars=TotalCars;
            LapNumberText.text =  "0";
            TotalLapsText.text = ("/   "+TotalLaps.ToString());
            TotalCarsText.text = ("/   "+TotalCars.ToString());
            PlayerPositionText.text="1";
        }

        // Update is called once per frame
        void Update()
        {
            SpeedText.text=(Mathf.Round(SaveScript.Speed).ToString());


            LapNumberText.text= SaveScript.LapNumber.ToString();


            if(SaveScript.LapTimeMinutes <= 9)
            {
                LapTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.LapTimeMinutes).ToString()) + ":";
            }
            else if (SaveScript.LapTimeMinutes >= 10)
            {
                LapTimeMinutesText.text = (Mathf.Round(SaveScript.LapTimeMinutes).ToString()) + ":";
            }
            if (SaveScript.LapTimeSeconds <= 9)
            {
                LapTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.LapTimeSeconds).ToString());
            }
            else if (SaveScript.LapTimeSeconds >= 10)
            {
                LapTimeSecondsText.text = (Mathf.Round(SaveScript.LapTimeSeconds).ToString());
            }


            if(SaveScript.RaceTimeMinutes <= 9)
            {
                RaceTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.RaceTimeMinutes).ToString()) + ":";
            }
            else if (SaveScript.RaceTimeMinutes >= 10)
            {
                RaceTimeMinutesText.text = (Mathf.Round(SaveScript.RaceTimeMinutes).ToString()) + ":";
            }
            if (SaveScript.RaceTimeSeconds <= 9)
            {
                RaceTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.RaceTimeSeconds).ToString());
            }
            else if (SaveScript.RaceTimeSeconds >= 10)
            {
                RaceTimeSecondsText.text = (Mathf.Round(SaveScript.RaceTimeSeconds).ToString());
            }


            if(SaveScript.LastLapTimeMinutes==SaveScript.BestLapTimeMinutes){
                if(SaveScript.LastLapTimeSeconds<SaveScript.BestLapTimeSeconds){
                    SaveScript.BestLapTimeSeconds=SaveScript.LastLapTimeSeconds;
                }
            }

            if(SaveScript.LastLapTimeMinutes<SaveScript.BestLapTimeMinutes){
                SaveScript.BestLapTimeMinutes=SaveScript.LastLapTimeMinutes;
                SaveScript.BestLapTimeSeconds=SaveScript.LastLapTimeSeconds;
            }

            if(SaveScript.BestLapTimeMinutes <= 9)
            {
                BestLapTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.BestLapTimeMinutes).ToString()) + ":";
            }
            else if (SaveScript.BestLapTimeMinutes >= 10)
            {
                BestLapTimeMinutesText.text = (Mathf.Round(SaveScript.BestLapTimeMinutes).ToString()) + ":";
            }
            if (SaveScript.BestLapTimeSeconds <= 9)
            {
                BestLapTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.BestLapTimeSeconds).ToString());
            }
            else if (SaveScript.BestLapTimeSeconds >= 10)
            {
                BestLapTimeSecondsText.text = (Mathf.Round(SaveScript.BestLapTimeSeconds).ToString());
            }

            if(SaveScript.LastLapTimeMinutes <= 9)
            {
                LastLapTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.LastLapTimeMinutes).ToString()) + ":";
            }
            else if (SaveScript.LastLapTimeMinutes >= 10)
            {
                LastLapTimeMinutesText.text = (Mathf.Round(SaveScript.LastLapTimeMinutes).ToString()) + ":";
            }
            if (SaveScript.LastLapTimeSeconds <= 9)
            {
                LastLapTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.LastLapTimeSeconds).ToString());
            }
            else if (SaveScript.LastLapTimeSeconds >= 10)
            {
                LastLapTimeSecondsText.text = (Mathf.Round(SaveScript.LastLapTimeSeconds).ToString());
            }

            PlayerPositionText.text=SaveScript.Player1Position.ToString();
        }
    }

