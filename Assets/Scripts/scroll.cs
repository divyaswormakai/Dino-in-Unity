using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    public Material material;
    public float xVel = 0.1f;
    Vector2 offset;
    player user;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        user = FindObjectOfType<player>();
    }

    void Update()
    {
        if (!user.gameOver)
        {
            offset = new Vector2(xVel, 0);
            material.mainTextureOffset += offset * Time.deltaTime;
        }
    }
}
