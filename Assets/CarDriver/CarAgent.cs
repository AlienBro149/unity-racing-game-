using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityStandardAssets.Vehicles.Car;
using Unity.VisualScripting;
using System;
using System.IO;

public class CarAgent : Agent
{

    [SerializeField] private TrackCheckpoints trackCheckPoints;
    [SerializeField] private Transform spawnPosition;

    private CarController carController;

    private int collisionWallCounter;
    private float carSpeed;
    private int wrongCheckpointCount = 0;
    private float TimeInterval;
    private Vector3 oldTransformPos;
    private int lapCount;
    private float startTimer;
    private float bestLapTime = 1000f;
    private string fileLapTimesName="";
    private int numberOfAttempts = 0;


    private void Awake()
    {
        carController= GetComponent<CarController>();
    }

    private void Start()
    {
        
        trackCheckPoints.OnPlayerCorrectCheckpoint += TrackCheckpoints_OnPlayerCorrectCheckpoint;
        trackCheckPoints.OnPlayerWrongCheckpoint += TrackCheckpoints_OnPlayerWrongCheckpoint;
        collisionWallCounter = 0;
        

        fileLapTimesName = Application.dataPath + "/laptimes/Combined25MBis";
    }

    private void TrackCheckpoints_OnPlayerWrongCheckpoint(object sender, TrackCheckpoints.CarCheckpointEventArgs e)
    {

        if (e.carTransform==transform)
        {
            AddReward(-1f);
            wrongCheckpointCount++;
        }
        if (wrongCheckpointCount >1)
        {
            AddReward(-3f);
            EndEpisode();
        }
        
    }

    private void TrackCheckpoints_OnPlayerCorrectCheckpoint(object sender, TrackCheckpoints.CarCheckpointEventArgs e)
    {
        if (e.carTransform==transform)
        {
            AddReward(1f);
            wrongCheckpointCount = 0;
            if (e.lastCheckpoint == true)
            {
                lapCount++;
                AddReward(2f);
                var currentTime = (Time.time - startTimer);
                startTimer = Time.time;
                var currentMinutes = Mathf.FloorToInt((currentTime) / 60);
                var currentSeconds = ((currentTime) % 60).ToString("F3");
                var currentlap = String.Format("{0:00}.", currentMinutes) + (currentSeconds);
                if (currentTime < bestLapTime)
                {
                    bestLapTime = currentTime;
                    AddReward(1f);
                }
                Debug.Log(transform + " Lapcount: " + lapCount
                    + " Last laptime: " + currentlap + " Best laptime: " + bestLapTime);
                WriteCsv(transform + ";" + lapCount+ ";" + currentTime + ";"+numberOfAttempts);
                numberOfAttempts++;
                WriteCsvAttempts(transform + ";" + numberOfAttempts);
            }
        }
    }

    public override void OnEpisodeBegin()
    {
        //used to stabilize car at the start
        transform.SetPositionAndRotation(spawnPosition.position, Quaternion.identity);
        transform.forward = spawnPosition.forward;
        trackCheckPoints.ResetCheckpoint(transform);
        Rigidbody body = gameObject.GetComponent<Rigidbody>();
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;

        //used for rewards
        carSpeed = 0f;
        oldTransformPos= Vector3.zero;
        lapCount = 0;
        startTimer = Time.time;
        numberOfAttempts++;
        WriteCsvAttempts(transform + ";" + numberOfAttempts);
        
        
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //Vector between cybertruck and nextCheckpoint
        
        Vector3 diff = trackCheckPoints.GetNextCheckpoint(transform).transform.position - transform.position;
        sensor.AddObservation(diff / 20f); //Divide by 20 to normalize

        carSpeed = SaveScript.Speed;

        if (carSpeed > 25)
        {
            AddReward(0.01f);
        }
        else if(carSpeed < 10)
        {
            AddReward(-0.01f);
        }
        
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {

        var action = actionsOut.ContinuousActions;

        action[0] = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W))
        {
            action[1] = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            action[1] = -1f;
        }
        else
        {
            action[1] = 0f;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Wall>(out _))
        {
            //Hit a wall or agent
            AddReward(-1f);

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Wall>(out _))
        {
            if (collisionWallCounter > 125)
            {
                collisionWallCounter = 0;
                EndEpisode();
            }
            collisionWallCounter++;
            //Stays on the wall
            AddReward(-0.05f);
        }

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        var input = actions.ContinuousActions;
        if (input[1]< 0)
        {//this is here to lower backwards speed
            
            input[1] = input[1] / 4;
        }
        carController.Move(input[0], input[1],0f);


    }

    private void Update()
    {
        // ones per in seconds
        TimeInterval += Time.deltaTime;
        if (TimeInterval >= 1)
        {
            TimeInterval = 0;
            Vector3 checkPointForward = trackCheckPoints.GetNextCheckpoint(transform).transform.forward;
            float directionDot = Vector3.Dot(transform.forward, checkPointForward);
            if (directionDot > 0.2f)
            {
                AddReward(0.01f);
            }
            else if (directionDot < 0f)
            {
                AddReward(-0.5f);
                EndEpisode();
            }

            if (oldTransformPos.x == transform.position.x && oldTransformPos.z == transform.position.z)
            {
                //Debug.Log("Static object: " + transform);
                EndEpisode();
            }
            oldTransformPos = transform.position;
        }
    }

    public void WriteCsv(string msg)
    {
        TextWriter tw = new StreamWriter(fileLapTimesName+ ".csv", true);
        tw.WriteLine(msg);
        tw.Close();
    }

    public void WriteCsvAttempts(string msg)
    {
        TextWriter tw = new StreamWriter(fileLapTimesName+"-attempts.csv", true);
        tw.WriteLine(msg);
        tw.Close();
    }
}