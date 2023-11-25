using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : SpawnedPool
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnFrequency;

    private void Start()
    {
        Initialize();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds spawndelay = new WaitForSeconds(_spawnFrequency);
        bool isSpawned = true;
        int spawnPointIndex;

        while (isSpawned)
        {
            spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            if(TryGetObject(out GameObject spawned))            
                spawned.transform.position = _spawnPoints[spawnPointIndex].position;
            
            yield return spawndelay;
        }
    }
}
