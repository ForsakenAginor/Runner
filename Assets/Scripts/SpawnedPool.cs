using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnedPool : MonoBehaviour
{
    [SerializeField] private int _poolSize;
    [SerializeField] private GameObject[] _enemyCarPrefabs;
    [SerializeField] private GameObject _fuelPrefab;
    [SerializeField] private int _fuelSpawnChance;
    [SerializeField] private GameObject _repairerPrefab;
    [SerializeField] private int _repairerSpawnChance;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize()
    {
        for (int i = 0; i < _fuelSpawnChance; i++)
        {
            GameObject spawned = Instantiate(_fuelPrefab, gameObject.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }

        for (int i = 0; i < _repairerSpawnChance; i++)
        {
            GameObject spawned = Instantiate(_repairerPrefab, gameObject.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }

        int randomPrefabIndex;

        for (int i = _fuelSpawnChance + _repairerSpawnChance;  i < _poolSize;  i++)
        {
            randomPrefabIndex = Random.Range(0, _enemyCarPrefabs.Length);
            GameObject spawned = Instantiate(_enemyCarPrefabs[randomPrefabIndex], gameObject.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        var deactivatedObjects = _pool.Where(o => o.activeSelf == false).ToList();

        if (deactivatedObjects.Count > 0 )
        {
            result = deactivatedObjects[Random.Range(0, deactivatedObjects.Count)];
            result.SetActive(true);
            return true;
        }

        result = null;
        return false;
    }
}
