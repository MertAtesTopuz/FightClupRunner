using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private bool Tyler;
    [SerializeField] private bool Jack;

    private bool left; // sol
    private bool right; // sağ

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if (Jack == true)
            {
                if (finger.deltaPosition.x > 100.0f)
                {
                    left = false;
                    right = true;
                }

                if (finger.deltaPosition.x < -100.0f)
                {
                    left = true;
                    right = false;
                }

                if (right == true)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(3.0f, transform.position.y, transform.position.z), speed * Time.deltaTime);
                }
                if (left == true)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(-3.0f, transform.position.y, transform.position.z), speed * Time.deltaTime);
                }
            }

            if (Tyler == true)
            {
                if (finger.deltaPosition.x > 100.0f)
                {
                    left = true;
                    right = false;
                }

                if (finger.deltaPosition.x < -100.0f)
                {
                    left = false;
                    right = true;
                }

                if (right == true)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(3.0f, transform.position.y, transform.position.z), speed * Time.deltaTime);
                }
                if (left == true)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(-3.0f, transform.position.y, transform.position.z), speed * Time.deltaTime);
                }
            }

        }
       
    }
}
