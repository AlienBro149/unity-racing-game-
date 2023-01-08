using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;



    public class SaveScript : MonoBehaviour
    {
        public static float Speed;
        public static int LapNumber;
        public static bool LapChange = false;
        public static float gameTime;

        public static float LapTimeMinutes;
        public static float LapTimeSeconds;

        public static float RaceTimeMinutes;
        public static float RaceTimeSeconds;

        public static float LastLapTimeMinutes;
        public static float LastLapTimeSeconds;

        public static float BestLapTimeMinutes;
        public static float BestLapTimeSeconds;

        public static bool CheckPointPass1=false;
        public static bool CheckPointPass2=false;
        public static bool CheckPointPass3=false;
        public static bool CheckPointPass4=false;
        public static bool CheckPointPass5=false;
        public static bool CheckPointPass6=false;
        public static bool CheckPointPass7=false;
        public static bool CheckPointPass8=false;
        public static bool CheckPointPass9=false;
        public static bool CheckPointPass10=false;
        public static bool CheckPointPass11=false;
        public static bool CheckPointPass12=false;
        public static bool CheckPointPass13=false;
        public static bool CheckPointPass14=false;
        public static bool CheckPointPass15=false;
        public static bool CheckPointPass16=false;

        public static bool OnTheRoad = true;
        public static bool OnTheTerrain = false;

        public static bool WrongWay = false;

        public static bool HalfWayActivated = true;

        public static bool RaceStart = false;
        public static bool RaceOver = false;
        public static int MaxLaps;
        public static int TotalCars;
        
        public static int Player1Position;

        public static int Player2LapNumber;





        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(RaceOver==false){
                if(LapChange == true){
                    LapChange=false;
                    LapTimeMinutes=0f;
                    LapTimeSeconds=0f;
                }
                
                if(LapNumber>=1){
                    LapTimeSeconds=LapTimeSeconds+1*Time.deltaTime;
                    RaceTimeSeconds=RaceTimeSeconds+1*Time.deltaTime;
                }

                if(LapTimeSeconds>59){
                    LapTimeSeconds=0f;
                    LapTimeMinutes++;
                }

                if(RaceTimeSeconds>59){
                    RaceTimeSeconds=0f;
                    RaceTimeMinutes++;
                }
            }
            
        }
    }

