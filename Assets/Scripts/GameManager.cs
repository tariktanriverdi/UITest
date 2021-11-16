using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
public class GameManager : MonoBehaviour
{


    public List<TargetIndex> targetsIndex = new List<TargetIndex>();
    public List<GameObject> targets;
    public float spawnRate=1.0f;
    public TextMeshProUGUI scoreText;
   private int score;
    void Start()
    {   StartCoroutine(nameof(SpawnTarget));
    score=0;
    scoreText.text="Score:"+score;
        // targetsIndex.Single(s => s.name=="Ob");
        //GameObject target=ObjectPooler.SharedInstance.GetPooledObject(targetsIndex.Single(s => s.name=="Good1").index);

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnTarget()
    {   while(true){
        GameObject target = ObjectPooler.SharedInstance.GetPooledObject(Random.Range(0, targetsIndex.Count));
        if (target != null) target.SetActive(true);
        yield return new WaitForSeconds(spawnRate);

    }
    }
}

