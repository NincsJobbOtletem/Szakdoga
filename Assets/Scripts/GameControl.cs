using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    [SerializeField]private Text getReadyText;
    [SerializeField] TextMeshProUGUI scoreText;
    public static int score,targetsHit;
    
    private float shotsFired;
    
    private float accuracy;

    private int targetsAmount;

    private Vector2 targetRandomPosition;
    
    void Start()
    {
    cursorHotspot = new Vector2(cursorTexture.width /2, cursorTexture.height / 2);
    Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);

    getReadyText.gameObject.SetActive(false);

    targetsAmount = 50;
    score = 0;
    shotsFired = 0;
    targetsHit = 0;
    accuracy = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "alma";
        if (Input.GetMouseButtonDown(0))
        {
            shotsFired += 1f;
        }
        Debug.Log(shotsFired);
    }
}
