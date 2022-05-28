using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {
    
    public float rotationSpeed=10;
	// Update is called once per frame
	void Update () 
    { 
                transform.Rotate(new Vector3(0,0,10) * rotationSpeed * Time.deltaTime); 
     }
}
