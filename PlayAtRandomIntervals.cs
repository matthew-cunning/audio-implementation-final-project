using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAtRandomIntervals : MonoBehaviour
{
    public AK.Wwise.Event eventToPlay;

    public float minRange;

    public float maxRange;
    private bool isPlaying = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlaying)
        {
            isPlaying = true;
            Debug.Log("Playing Sound...");
            StartCoroutine(PlayAtRandomInterval());
        }

    }

    IEnumerator PlayAtRandomInterval()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(Random.Range(minRange,maxRange));
        eventToPlay.Post(gameObject);
        Debug.Log("Done!");
        isPlaying = false;
    }

}
