using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float Heightrange = 3f;
    [SerializeField] private float spawnRate = 2f;
    void Start()
    {
        StartCoroutine(SpawnPipesRoutine());
    }

    IEnumerator SpawnPipesRoutine()
    {
        while(!GameManager.Instance.IsGameStarted())
        {
            yield return null;
        }

        while (true)
        {
            if(GameManager.Instance.IsGameStarted() && !GameManager.Instance.IsGameOver())
            {
                SpawnPipe();
            }
            
            yield return new WaitForSeconds(spawnRate);
        }
    }
    void SpawnPipe()
    {
        if(pipePrefab == null)Debug.Log("Pipe Prefab is NULL");
        float randomY = Random.Range(-Heightrange, Heightrange);
        Vector3 spawnPosition = new Vector3(10, randomY, 0);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
