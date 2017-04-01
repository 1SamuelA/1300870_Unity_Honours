using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    public Text CountdownTimeText;

    float spawnCooldown = 0.5f;

    float spawnCDremaining = 10.0f;
    float spawnTimer = 10.0f;

    [System.Serializable]
    public class WaveComponent
    {
        public GameObject enemyPrefab;
        public int num;
        [System.NonSerialized]
        public int spawned = 0;
    }

    public WaveComponent[] waveComps;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnCDremaining -= Time.deltaTime;

        

        CountdownTimeText.text = "Next Wave: " + System.Math.Round(spawnTimer, 2).ToString();
        if (spawnTimer > 0)
        {

            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                spawnTimer = 0;
            }


        }

        ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();

        if (spawnCDremaining <= 0)
        {
            spawnCDremaining = spawnCooldown;
            bool DidSpawn = false;

            foreach(WaveComponent wc in waveComps)
            {
                if(wc.spawned < wc.num)
                {
                    Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);
                    wc.spawned++;
                    DidSpawn = true;
                    break;
                }
            }
            if( DidSpawn == false)
            {

                if(transform.parent.childCount>1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }

                Destroy(gameObject);
            }
        }
	}
}
