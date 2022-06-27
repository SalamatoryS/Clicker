using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int health = 1;
    float verticalMax = 4.3f;
    float verticalMin = - 5f;
    int toScore = 10;
    Vector3 enemyMove = Vector3.down;
    GameManager addScore;

    private void Start()
    {
        addScore = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (gameObject.transform.position.y < 0)
            TurnEnemy();
    }

    private void Update()
    {
        PhoneController();
        CheckDamage();
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    public void EnemyUp()
    {
        speed ++;
        health++;
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

    //May be the PhoneController isn't work
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

    void CheckDamage()
    {
        if (health == 0)
        {
            addScore.IncreaseScore(toScore);
            GameManager.monsterCount--;
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        health--;
    }


}
