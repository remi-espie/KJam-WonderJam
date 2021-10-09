using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public void Open()
    {
        Destroy(transform.gameObject);
    }
}
