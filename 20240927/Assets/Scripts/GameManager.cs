using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject WallPrefab;
    public float SpawnTerm = 4;

    float spawnTimer;
    public float score;
    public float Score 
    {     
        get
        { 
            return score; 
        }
    }

    private void Awake() //start���� ���� ����
    {
        Instance = this;
    }

    void Start()
    {
        spawnTimer = 0f;
        score = 0;
        //Score = 0; �̰� setter�� �θ��� ����
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        score += Time.deltaTime;

        if(spawnTimer > SpawnTerm)
        {
            spawnTimer -= SpawnTerm;

            GameObject obj = Instantiate(WallPrefab);

            obj.transform.position = new Vector2(10, Random.Range(-2f, 2f));
        }
    }
}
