using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public float scrollSpeed = 10f;
    public Transform spawnPoint;
    public Transform endPoint;

    float counter = 0f;

    player user;
    void Start()
    {
        GenerateEnemies();
        user = FindObjectOfType<player>();
    }

    void GenerateEnemies()
    {
        GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoint.position, Quaternion.identity);
        newEnemy.transform.parent = transform;

        counter = 1f;
    }

    void MoveEnemy(GameObject currEnemy)
    {
        currEnemy.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (!user.gameOver)
        {
            if (counter <= 0)
            {
                GenerateEnemies();
            }
            else
            {
                counter -= Time.deltaTime;
            }

            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject currChild = transform.GetChild(i).gameObject;
                MoveEnemy(currChild);
                if (transform.GetChild(i).position.x <= endPoint.position.x)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
