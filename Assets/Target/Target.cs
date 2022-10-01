using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

public class Target : MonoBehaviour
{

    private float time;
    // Start is called before the first frame update
    void Start()
    {
     Destroy(gameObject, 1f);
        time = Time.time;
       
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Delta time" + Time.deltaTime);

    }
    private void OnMouseDown() {
        GameControl.score += 10;
        GameControl.targetsHit += 1;
        GameControl.finalTime += Time.time-time;

        Destroy(gameObject);
        
    }
}
