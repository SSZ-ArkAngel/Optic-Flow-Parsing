using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    
    public float egoVelocity = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3(0.0f, 0.0f, egoVelocity);
        Vector3 displacement = Time.deltaTime * velocity; // accounts for frame rates to make sure the object moves at the speed defined
        transform.localPosition = transform.localPosition + displacement;
    }
}
