using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//High Rise Invasion

public class NpcContoller : MonoBehaviour
{
    [Header("General")]
    private Animator anim;
    private Rigidbody playerRb;
    private BoxCollider boxCol;

    private Rigidbody[] rbs;
    private Collider[] cols;

    private UIManager UI;

    [Header("Effect")]
    [SerializeField] private GameObject angryEffect;
    [SerializeField] private GameObject happyEffect;

    [Header("Timer")]
    private bool DeathTimer = false;
    private float time;
    [SerializeField] private float maxTime = 10f;

    [Header("NpcSettings")]
    [SerializeField] private bool redNpc;
    [SerializeField] private bool blueNpc;
    [SerializeField] private bool back;
    [SerializeField] private bool forward;
    private bool tForce = false;

    private void Awake()
    {
        time = maxTime;
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

        int rand = Random.Range(1, 6);

        if (rand == 1)
        {
            anim.SetBool("isSadI", true);
        }

        else if(rand == 2)
        {
            anim.SetBool("isNaturalI", true);
        }

        else if (rand == 3)
        {
            anim.SetBool("isDwarfI", true);
        }

        else if (rand == 4)
        {
            anim.SetBool("isHappyI", true);
        }

        else if (rand == 5)
        {
            anim.SetBool("isOrcI", true);
        }
    }

    void Update()
    {
        if (DeathTimer == true)
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
            if (tForce == true)
            {
                if (back == true)
                {
                   playerRb.AddForce(transform.forward * 1000f);
                }
                else if (forward == true)
                {
                   playerRb.AddForce(-transform.forward * 1000f);
                }
            }
            

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
                tForce = true;
                
            }

            if (other.tag == "HandT")
            {
                happyEffect.SetActive(true);
                DeathTimer = true;
                UI.currentValue += 1;
                time = maxTime;
                ActivateRagdoll();

            }

            else if (other.tag == "Jack")
            {
                DeathTimer = true;
                time = maxTime;
                anim.SetBool("getAngry", true);
                angryEffect.SetActive(true);

                if (UI.currentValue > 0)
                {
                    UI.currentValue -= 1;
                }
            }
        }

        if (blueNpc == true)
        {
            if (other.tag == "Tyler")
            {
                tForce = true;
            }

            if (other.tag == "HandT")
            {
                DeathTimer = true;
                angryEffect.SetActive(true);

                if (UI.currentValue > 0)
                {
                    UI.currentValue -= 1;
                }
                time = maxTime;

                ActivateRagdoll();
            }

            else if (other.tag == "Jack")
            {
                DeathTimer = true;
                time = maxTime;
                happyEffect.SetActive(true);
                anim.SetBool("isWaving", true);

                UI.currentValue += 1;
            }
        } 
    }
}
