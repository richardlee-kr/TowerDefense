using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    private void Start()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameisOver)
        {
            this.enabled = false;
            return;
        }
        float moveY = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Mouse ScrollWheel")*10;

        transform.Translate(moveX, moveY, moveZ);
    }
}
