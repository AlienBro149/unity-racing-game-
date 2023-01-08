using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLightScript : MonoBehaviour
{
    public GameObject Countone;
    public GameObject Counttwo;
    public GameObject Countthree;
    public GameObject GO;



    public AudioSource BeepSound1;
    public AudioSource BeepSound2;
    // Start is called before the first frame update
    void Start()
    {
        Countone.SetActive(false);
        Counttwo.SetActive(false);
        Countthree.SetActive(false);
        GO.SetActive(false);
        StartCoroutine(StartingLights());
    }



    IEnumerator StartingLights()
    {
        yield return new WaitForSeconds(1);
        BeepSound1.Play();
        Countthree.SetActive(true);

        yield return new WaitForSeconds(1);
        BeepSound1.Play();
        Countthree.SetActive(false);
        Counttwo.SetActive(true);

        yield return new WaitForSeconds(1);
        BeepSound1.Play();
        Counttwo.SetActive(false);
        Countone.SetActive(true);

        yield return new WaitForSeconds(1f);
        BeepSound2.Play();
        Countone.SetActive(false);
        GO.SetActive(true);


        yield return new WaitForSeconds(.5f);
        SaveScript.RaceStart = true;
        GO.SetActive(false);
        

    }
}
