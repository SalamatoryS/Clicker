using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;

    float verticalTop = 4.3f;
    float horizontalTop = 2.6f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, 2);
    }

    void SpawnEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(-horizontalTop, horizontalTop), Random.Range(-verticalTop, verticalTop));
        Instantiate(enemy, pos, enemy.gameObject.transform.rotation);
    }

}
