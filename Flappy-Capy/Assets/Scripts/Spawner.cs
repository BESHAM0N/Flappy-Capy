using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate = 1f;

    public float minHeight = -20f;
    public float maxHeight = 20f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }


    private void Spawn()
    {
        GameObject fence = Instantiate(prefab, transform.position, Quaternion.identity);
        fence.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
