using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerSelectLevel : CameraController
{
    [SerializeField] List<Transform> tab;
    [SerializeField] Vector3 offset;
    int index = 0;
    float smoothSpeed = 2.5f;
    bool camera_move_enabled = false;
    Vector3 desiredPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            base.Invoke("NextPos", 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            base.Invoke("PreviousPos",0.5f);
        }

    }

    private void FixedUpdate()
    {
        if (camera_move_enabled)
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        if (transform.position == desiredPosition)
            camera_move_enabled = false;
    }

    void NextPos()
    {
        index++;
        if (index > tab.Count - 1)
        {
            index = tab.Count - 1;
            //Debug.Log("Change scene");
        }
        else
        {
            desiredPosition = tab[index].position + offset;
            desiredPosition.x = 0;
            Debug.Log(desiredPosition);
            camera_move_enabled = true;
        }

    }

    void PreviousPos()
    {
        index--;
        if (index < 0)
        {
            index = 0;
            //Debug.Log("Change scene");
        }
        else
        {
            desiredPosition = tab[index].position + offset;
            desiredPosition.x = 0;
            Debug.Log(desiredPosition);
            camera_move_enabled = true;
        }

    }
}
