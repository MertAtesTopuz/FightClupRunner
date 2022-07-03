using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrigger : MonoBehaviour
{

    NpcContoller npc;

    void Start()
    {
        npc = GetComponent<NpcContoller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Npc")
        {
            // other.attachedRigidbody.AddForce(-transform.forward * 1000f);
            npc.ActivateRagdoll();
        }
    }
}
