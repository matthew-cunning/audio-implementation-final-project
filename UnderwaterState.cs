using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterState : MonoBehaviour
{
    public GameObject player;
    public AK.Wwise.Event underwaterEnter;
    public AK.Wwise.Event underWaterExit;

    private bool underwater;

    private float waterLevel = 13.8f;
    // Start is called before the first frame update
    void Start()
    {
        underwater = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y <= waterLevel)
        {
            if(!underwater)
                underwaterEnter.Post(this.gameObject);

            underwater = true;
        }

        else
        {
            if(underwater)
                underWaterExit.Post(this.gameObject);

            underwater = false;
        }
            
    }
}
