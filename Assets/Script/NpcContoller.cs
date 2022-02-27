using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcContoller : MonoBehaviour
{
    [SerializeField] private bool redNpc;
    [SerializeField] private bool blueNpc;
    public bool deneme = false;

    public float time;
    [SerializeField] private float maxTime = 10f;

    private Animator anim;
    private Rigidbody playerRb;
    private BoxCollider boxCol;

    private Rigidbody[] rbs;
    private Collider[] cols;

    private UIManager UI;

    private void Awake()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        cols = GetComponentsInChildren<Collider>();
        playerRb = GetComponent<Rigidbody>();
        boxCol = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        UI = FindObjectOfType<UIManager>();

        SetCollidersEnabled(false);
        SetRbsKinematic(true);
        playerRb.isKinematic = false;
        boxCol.enabled = true;
    }

    void Update()
    {
        if (deneme == true)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            Destroy(gameObject);
        }
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

    public void ActivateRagdoll()
    {
        boxCol.enabled = false;
        playerRb.isKinematic = true;
        anim.enabled = false;

        SetCollidersEnabled(true);
        SetRbsKinematic(false);
        boxCol.enabled = enabled;
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (redNpc == true)
        {
           
            if (other.tag == "Tyler")
            {
                deneme = true;
                UI.currentValue += 1;
                time = maxTime;
                ActivateRagdoll();
                
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

}
