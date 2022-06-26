using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int health = 1;
    float verticalMax = 4.3f;
    float verticalMin = - 5f;
    int toScore;
    Vector3 enemyMove = Vector3.down;

    private void Start()
    {
        if (gameObject.transform.position.y < 0)
            TurnEnemy();

    }

    private void Update()
    {
        PhoneController();
        if (health == 0)
        {
            Destroy(gameObject);
        }
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

    void PhoneController()
    {
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    health--;
                }
            }
        }
    }
    private void OnMouseDown()
    {
        health--;
    }


}
