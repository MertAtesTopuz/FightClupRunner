using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcContoller : MonoBehaviour
{
    [SerializeField] private bool redNpc;
    [SerializeField] private bool blueNpc;
    [SerializeField] private float speed;
    [SerializeField] private float speed2;
    private Animator anim;
    private Rigidbody playerRb;
    private BoxCollider boxCol;

    private Rigidbody[] rbs;
    private Collider[] cols;

    

    private void Awake()
    {
        inAwake();
    }

    void Update()
    {
        //bu silinecek
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActivateRagdoll();
        }
    }

    private void inAwake()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        cols = GetComponentsInChildren<Collider>();
        playerRb = GetComponent<Rigidbody>();
        boxCol = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();

        SetCollidersEnabled(false);
        SetRbsKinematic(true);

    }

    private void SetCollidersEnabled(bool enabled)
    {
        foreach (Collider col in cols)
        {
            col.enabled = enabled;
        }
    }

    private void SetRbsKinematic(bool kinematic)
    {
        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = kinematic;
        }
    }

    private void ActivateRagdoll()
    {
        boxCol.enabled = false;
        playerRb.isKinematic = true;
        anim.enabled = false;

        SetCollidersEnabled(true);
        SetRbsKinematic(false);
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (redNpc == true)
        {
           
            if (other.tag == "Tyler")
            {
                anim.enabled = false;
                // activateRagdoll çalışacak
                // mutlu olma particle sytem devreye girecek
                // uı kodundaki slider kodu aktive olacak
                // 5 saniye sonra destrot edilecek
            }

            else if (other.tag == "Jack")
            {
                    Destroy(gameObject);
                    // animatorden uygun animasyon çalışacak
                    // sinirlenme particle sytem devreye girecek
                    // 5 saniye sonra destrot edilecek
            }


        }

        if (blueNpc == true)
        {
            if (other.tag == "Tyler")
            {
                Destroy(gameObject);
                // activateRagdoll çalışacak
                // sinirlenme particle sytem devreye girecek
                // 5 saniye sonra destrot edilecek
            }

            else if (other.tag == "Jack")
            {
                Destroy(gameObject);
                // animatorden uygun animasyon çalışacak
                // mutlu olma particle sytem devreye girecek
                // uı kodundaki slider kodu aktive olacak
                // 5 saniye sonra destrot edilecek
            }

        } 
    }

    IEnumerator BlueTyler()
    {
       yield return new WaitForSeconds(speed);
    } 

}
