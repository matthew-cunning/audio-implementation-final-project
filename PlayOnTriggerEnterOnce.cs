using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTriggerEnterOnce : MonoBehaviour
{
    // Start is called before the first frame update
    public AK.Wwise.Event eventToPlay;
    private bool hasPlayed;
    void Start()
    {
        hasPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(!hasPlayed)
        {
            eventToPlay.Post(this.gameObject);
        }

        hasPlayed = true;

    }
}
