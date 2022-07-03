using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isRunning = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isRunning == true)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        
    }
}
