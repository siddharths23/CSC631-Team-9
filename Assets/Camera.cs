using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private bool topView = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            topView = !topView;
            if (topView) {
                transform.position = new Vector3(0, 10, 0);
                transform.Rotate(90, 0, 0);
            } else {
                transform.position = new Vector3(0, 1, -5);
                transform.Rotate(-90, 0, 0);
            }
        }
    }
}
