using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcContoller : MonoBehaviour
{
    [SerializeField] private bool redNpc;
    [SerializeField] private bool blueNpc;
    [SerializeField] private float speed;
    [SerializeField] private float speed2;
    public List<Collider> ragdollParts = new List<Collider>();

    private void Awake()
    {
        SetRagdollPart();
        inAwake();
    }

    void Update()
    {
        
    }

    private void inAwake()
    {
        

    }

    private void SetRagdollPart()
    {
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {
                //c.isTrigger = true;
                ragdollParts.Add(c);
            }
        }
    }

    private void TurnRagdollParts()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (redNpc == true)
        {
           
                if (other.tag == "Tyler")
                {
                    Destroy(gameObject);
                }

                else if (other.tag == "Jack")
                {
                    Destroy(gameObject);
                }

            
        }

        if (blueNpc == true)
        {
            if (other.tag == "Tyler")
            {
                Destroy(gameObject);
            }

            else if (other.tag == "Jack")
            {
                Destroy(gameObject);
            }

        } 
    }

      IEnumerator BlueTyler()
      {
          yield return new WaitForSeconds(speed);
          
      } 

}
