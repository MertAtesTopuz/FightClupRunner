using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform Target;
    Vector3 mesafe;
        
    void Start()
    {
        
    }

    void LateUpdate()
    {
        mesafe = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z - 11.0f);

        transform.position = Vector3.Lerp(transform.position, mesafe, Time.deltaTime);
    }
}
