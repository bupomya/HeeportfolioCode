using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 10f, 0) * rotateSpeed * Time.deltaTime);
    }
}
