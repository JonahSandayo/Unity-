using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private float speed;

    void Start()
    {
        speed = GameManager.Instance.obstacleSpeed;
    }

    void Update()
    {
                transform.position += Vector3.left * speed * Time.deltaTime;

        // 画面外で削除
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
