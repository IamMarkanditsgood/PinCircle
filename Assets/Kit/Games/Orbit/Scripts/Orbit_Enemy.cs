using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit_Enemy : MonoBehaviour
{
    float speed = 0.05f;
    void Update()
    {
        transform.position += transform.up * speed;
    }
}
