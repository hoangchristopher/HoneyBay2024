using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance {get; private set;}

    public GameObject applePrefab;
    public GameObject cameraView;

    public float forwardDistance = 1f;
    public float sideDistance = 1f;

    private float timer = 0f;
    private bool running = false;

    public int count = 0;

    public double addedScore = 0;

    public double averageTime;



    public TextMeshProUGUI appleText;
    public TextMeshProUGUI timeText;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!running && timer > 1f){
            running = true;
            Spawn();
        }

        if (running){
        timeText.text = "TIME: " + Math.Round(timer,2).ToString();

            if (count >= 20){
                if (averageTime == 0) {
                    averageTime = Math.Round(timer/20,2);
                }
                timeText.text = "FINISH\nAVERAGE TIME: " + Math.Round(averageTime,2).ToString();
                addedScore = averageTime / 80;
                ScoreScript.totalScore += addedScore;
                StartCoroutine(NextScene());

                

                
            }

        }



        
    }

    private IEnumerator NextScene() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Stage3");
        Destroy(gameObject);

    }

    public void Spawn(){
        Vector3 randomPos = cameraView.transform.position + cameraView.transform.forward * forwardDistance
            + cameraView.transform.up * UnityEngine.Random.Range(-sideDistance,sideDistance)
            + cameraView.transform.right * UnityEngine.Random.Range(-sideDistance,sideDistance);
        if (running){
            Instantiate(applePrefab, randomPos, Quaternion.identity);
            count++;
            appleText.text = "APPLES: " + count.ToString();
        }
    }


}
