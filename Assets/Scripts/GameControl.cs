using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Texture2D cursorTexture;

    private Vector2 cursorHotspot;
    
    private Vector2 mousePos;

    [SerializeField]
    private GameObject resultsPanel;

    [SerializeField] TextMeshProUGUI getReadyText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TextMeshProUGUI targetsHitText;

    [SerializeField] TextMeshProUGUI shotsFiredText;

    [SerializeField] TextMeshProUGUI accuracyText;

    [SerializeField] TextMeshProUGUI msText;
    public static int score,targetsHit;
    
    public static float finalTime;
    private float shotsFired;
    
    private float accuracy;

    private float timeReduceWhileTimeIsRunning;

    private int targetsAmount;

    private Vector2 targetRandomPosition;
    
    void CreateText(){
        string path = Application.dataPath + "/Log.txt";
        string content;
        if(!File.Exists(path)){
            File.WriteAllText(path,"Name: "+ SystemInfo.deviceName + "\n\n");
        }
        content = "\n Result \n" +" Shots Fired: "+shotsFired + " Accuracy: "+ accuracy.ToString("N2") +" Targets Hit: " + targetsHit + "/" + targetsAmount+"Shots Fired: " + shotsFired+" Score: "+score +(finalTime/targetsHit*1000).ToString("N0")+ "\n"+"-----------------------------------------------------------------------";

        File.AppendAllText(path,content);
    }

    void Start()
    {
    
    cursorHotspot = new Vector2(cursorTexture.width /2, cursorTexture.height / 2);
    Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);

    getReadyText.gameObject.SetActive(false);

    targetsAmount = 3;
    score = 0;
    shotsFired = 0;
    targetsHit = 0;
    accuracy = 0f;
    
    }
    // Update is called once per frame
    void Update()
    {

        //scoreText.text = "alma";
        if (Input.GetMouseButtonDown(0))
        {
            shotsFired += 1f;
        }
            
    }
    private IEnumerator GetReady(){
        for (int i=5;i >= 1; i--)
        {
            getReadyText.text = "Get Ready!\n" + i.ToString();
            yield return new WaitForSeconds(1f);
        }
        getReadyText.text = "Go!";
        yield return new WaitForSeconds(1f);

        StartCoroutine("SpawnTargets");
    }
    private IEnumerator SpawnTargets(){
        getReadyText.gameObject.SetActive(false);
        score = 0;
        shotsFired = 0;
        targetsHit = 0;
        accuracy = 0;
        timeReduceWhileTimeIsRunning = 2f;
        
        for (int i = targetsAmount; i >= 0; i--){
            targetRandomPosition = new Vector2(Random.Range(-7f, 7f), Random.Range(-4f, 4f));
            Instantiate(target, targetRandomPosition, Quaternion.identity);
            yield return new WaitForSeconds(timeReduceWhileTimeIsRunning);
            accuracy = targetsHit / shotsFired * 100f;
            if (accuracy <= 75){
                timeReduceWhileTimeIsRunning *= 1.10f;
                Debug.Log("Reflex=: "+finalTime);
            }
            else{
                timeReduceWhileTimeIsRunning *= 0.95f;
                Debug.Log("Reflex=: "+finalTime);
                // Debug.Log("accuracy" + accuracy);
                // Debug.Log("Uj target time" + timeReduceWhileTimeIsRunning);
            }



        }
        targetsAmount++;
        Debug.Log("átlag ms reflex" + (finalTime/targetsHit*1000).ToString("N0"));
        resultsPanel.SetActive(true);
        scoreText.text = "Score: " + score;
        targetsHitText.text = "Targets Hit: " + targetsHit + "/" + targetsAmount;
        shotsFiredText.text = "Shots Fired: " + shotsFired;
        accuracy = targetsHit / shotsFired * 100f;
        accuracyText.text = "Accuracy: " + accuracy.ToString("N2") + "%";
        msText.text = "MS: " + (finalTime/targetsHit*1000).ToString("N0");
        
        CreateText();
        
    }
    public void StartGetReadyCoroutine(){
    resultsPanel.SetActive(false);
    getReadyText.gameObject.SetActive(true);
    StartCoroutine("GetReady");

    }

}
