using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatonTrigger : MonoBehaviour
{
    public Animator animT;
    public Animator animJ;
    private BoxCollider col;
    public AnimationTimer timer;

    [Header("Character")]
    [SerializeField] private bool Tyler;
    [SerializeField] private bool Jack;

    [Header("Timer")]
    private bool activeTimer = false;
    public float time;
    [SerializeField] private float maxTime = 10f;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void Update()
    {

        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Tyler== true)
        {
            if (other.transform.tag == "Npc")
            {
                timer.time = maxTime;
                gameObject.SetActive(false);
                animT.SetTrigger("isPunch");
                
            }
        }

        if (Jack == true)
        {
            if (other.transform.tag == "Npc")
            {
                timer.time = maxTime;
                gameObject.SetActive(false);
                animJ.SetTrigger("isPunch");
                
            }
        }
    }
}
