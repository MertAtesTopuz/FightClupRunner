using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimer : MonoBehaviour
{
    public float time;
    public GameObject trigger;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            trigger.SetActive(true);
        }
    }
}
