using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float hiz;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, hiz * Time.deltaTime, 0, Space.World);
    }
}
