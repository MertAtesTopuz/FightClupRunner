using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftJack : MonoBehaviour
{
    public Animator anim;
    private NpcContoller npc;
    public Rigidbody rb;

    void Start()
    {
        npc = GetComponent<NpcContoller>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Npc")
        {
            anim.SetTrigger("isLeftPunch");
            rb.AddForce(-transform.forward * 500);
        }
        
    }
}
