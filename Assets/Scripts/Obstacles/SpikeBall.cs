using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public float rotationAngle = 90f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void RotationSpikeBall()
    {
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        RotationSpikeBall();
    }
}