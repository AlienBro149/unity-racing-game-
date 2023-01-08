using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class TrackCheckpoints : MonoBehaviour {

    public event EventHandler<CarCheckpointEventArgs> OnPlayerCorrectCheckpoint;
    public event EventHandler<CarCheckpointEventArgs> OnPlayerWrongCheckpoint;

    [SerializeField] private List<Transform> carTransformList;


    private List<CheckpointSingle> checkpointSingleList;
    private List<int> nextCheckpointSingleIndexList;
    private bool lastCheckpointInTrack;

    private void Awake() {
        Transform checkpointsTransform = transform.Find("AiCheckpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform) {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);

            checkpointSingleList.Add(checkpointSingle);
        }


        PopulateNextCheckpointList();
    }



    public void CarThroughCheckpoint(CheckpointSingle checkpointSingle, Transform carTransform) {
        
        int nextCheckpointSingleIndex = nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)];
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex) {
            // Correct checkpoint
            CheckpointSingle correctCheckpointSingle = checkpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointSingle.Hide();
            if (correctCheckpointSingle == checkpointSingleList[checkpointSingleList.Count-1])
            {
                lastCheckpointInTrack = true;
            }
            nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)]
                = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this,new CarCheckpointEventArgs(carTransformList[carTransformList.IndexOf(carTransform)],lastCheckpointInTrack));
            lastCheckpointInTrack= false;
        } else { 
            // Wrong checkpoint
            OnPlayerWrongCheckpoint?.Invoke(this, new CarCheckpointEventArgs(carTransformList[carTransformList.IndexOf(carTransform)],lastCheckpointInTrack));

            CheckpointSingle correctCheckpointSingle = checkpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointSingle.Show();
        }
    }
    public class CarCheckpointEventArgs : EventArgs
    {
        public Transform carTransform { get; set; }

        public bool lastCheckpoint { get; set; }

        public CarCheckpointEventArgs(Transform carTransform, bool lastCheckpoint)
        {
            this.carTransform = carTransform;
            this.lastCheckpoint = lastCheckpoint;
        }
    }

    public CheckpointSingle GetNextCheckpoint(Transform transform)
    {
        int checkpointIndex = nextCheckpointSingleIndexList[carTransformList.IndexOf(transform)];
        return checkpointSingleList[checkpointIndex];

    }

    private void PopulateNextCheckpointList()
    {
        nextCheckpointSingleIndexList = new List<int>();
        foreach (Transform carTransform in carTransformList)
        {
            nextCheckpointSingleIndexList.Add(0);
        }
    }

    public void ResetCheckpoint(Transform carTransform)
    {
        
        nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)] = 0;
        

        foreach (CheckpointSingle point in checkpointSingleList)
        {
            point.Hide();
        }


    }
}
