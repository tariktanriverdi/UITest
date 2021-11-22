using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

   
    public List<TargetIndex> targetsIndex = new List<TargetIndex>();
    public List<GameObject> targets;
    public float spawnRate = 1.0f;
    public GameObject scoreText;
    //public TextMeshProUGUI scoreText;
    private int score;
    public GameObject gameOverPanel;
    bool isGameActive=true;
     #region Singleton

    private static GameManager _instance;
    public static GameManager Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
        {

            Destroy(gameObject);

        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    void Start()
    {     Time.timeScale=1;
        StartCoroutine(nameof(SpawnTarget));
        score = 0;
        isGameActive=true;
        // targetsIndex.Single(s => s.name=="Ob");
        //GameObject target=ObjectPooler.SharedInstance.GetPooledObject(targetsIndex.Single(s => s.name=="Good1").index);

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            GameObject target = ObjectPooler.SharedInstance.GetPooledObject(Random.Range(0, targetsIndex.Count));
            if (target != null) {
            target.SetActive(true);  
           
            }
            
            yield return new WaitForSeconds(spawnRate);

        }
    }
    public void UpdateScore(int scoreToAdd)
    {  
        score += scoreToAdd;
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:"+score;
    
    }
    public void GameOver(){
      gameOverPanel.SetActive(true);
      isGameActive=false;
      scoreText.SetActive(false);
      Time.timeScale=0;
    }
    public void TryAgain(){
        gameOverPanel.SetActive(false);
         scoreText.SetActive(true);
         SceneManager.LoadScene("Prototype 5");
        //relod sceen
     }
    public void Exit(){
        //exit
    }

}

