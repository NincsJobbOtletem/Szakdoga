using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     Destroy(gameObject, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
        GameControl.score += 10;
        GameControl.targetsHit += 1;
        Destroy(gameObject);
    }
}
