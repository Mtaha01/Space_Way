using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naveMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 3;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
    }
}
