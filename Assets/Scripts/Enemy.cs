using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    float verticalMax = 4.3f;
    float verticalMin = - 5f;
    Vector3 enemyMove = Vector3.down;

    private void Start()
    {
        if (gameObject.transform.position.y < 0)
            TurnEnemy();
    }
    private void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        gameObject.transform.Translate(enemyMove * speed * Time.deltaTime, Space.World);
        if (gameObject.transform.position.y < verticalMin)
            TurnEnemy();
        if (gameObject.transform.position.y > verticalMax)
            TurnEnemy();
    }

    void TurnEnemy()
    {
        enemyMove = -enemyMove;
        gameObject.transform.Rotate(0, 180, 0);
    }
}
