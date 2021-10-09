using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
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
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            NextPos();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PreviousPos();
        }
        */
    }

    private void FixedUpdate()
    {
        if(camera_move_enabled)
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        if (transform.position == desiredPosition)
            camera_move_enabled = false;
    }

    public void NextPos()
    {
        index++;
        if(index > tab.Count-1)
        {
            index = tab.Count - 1;
            //Debug.Log("Change scene");
        }
        else
        {
            desiredPosition = tab[index].position + offset;
            Debug.Log(desiredPosition);
            camera_move_enabled = true;
        }
        
    }

    public void PreviousPos()
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
            Debug.Log(desiredPosition);
            camera_move_enabled = true;
        }

    }
}

