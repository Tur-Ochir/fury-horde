using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AISpawner : MonoBehaviour
{
    public AICharacterManager aiPrefab;
    public int count;
    public float radius;
    
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var r = Random.insideUnitCircle * radius;
            Spawn(new Vector3(r.x, transform.position.y, r.y));
        }
    }

    private void Spawn(Vector3 pos)
    {
        var ai = Instantiate(aiPrefab, pos, Quaternion.identity);
        ai.currentTarget = player;
    }
}
