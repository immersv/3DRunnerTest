using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    // Use this for initialization
    public RunnerController runner;
    public Camera mainCamera;
    public Text text;
    private bool isGameOver;
    public GameObject[] groundPlanePrefabs;
    private float blockpointer = -10;
    private float safeDistance = 5;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        while (runner != null && blockpointer < runner.transform.position.x + safeDistance)
        {
            int planeIndex = Random.Range(0, groundPlanePrefabs.Length);
            GameObject planeObject = GameObject.Instantiate<GameObject>(groundPlanePrefabs[planeIndex]);
            planeObject.transform.SetParent(this.transform);
            GroundController plane = planeObject.GetComponent<GroundController>();

            planeObject.transform.position = new Vector3(blockpointer + plane.groundPlaneSize / 2, 0, 0);

            blockpointer += plane.groundPlaneSize;
        }
        if (runner != null)
        {
            mainCamera.transform.position = new Vector3(runner.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
            text.text = "Score : " + Mathf.Floor(runner.transform.position.x);
        }
        else if(!isGameOver)
        {
            isGameOver = true;
            text.text += "\nPress P to Play Again";
        }
        if (Input.GetKeyDown("p"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
    }
        
}
