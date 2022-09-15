using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    // Start is called before the first frame update
    [SerializeField]
    private Texture2D cursorTexture;

    private Vector2 cursorHotspot;
    
    private Vector2 mousePos;

    [SerializeField]
    private GameObject resultsPanel;

    [SerializeField]
    private TextMesh scoreText,targetsHitText,shotsFiredText,accuracyText;

    public static int score,targetsHit;
    
    private float shotsFired;
    
    private float accuracy;

    private int targetsAmount;

    private Vector2 targetRandomPosition;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
