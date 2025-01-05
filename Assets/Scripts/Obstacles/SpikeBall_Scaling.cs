using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall_Scaling : MonoBehaviour
{
    public float rotateAngle = 90f;

    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    public float scaleSpeed = 15f;
    private float scaleFactor = 1f;
    private float currentScale;

    public float scaleDelay = 2f;
    private float timer = 0f;
    private bool isWaiting = false;

     void Start()
    {
        currentScale = minScale;
        ApplyCurrentScale();
    }

     void Update()
    {
        RotateSpikeBall();

        if (isWaiting)
            HandleWaiting();
        else 
            ScaleSpikeBall();
    }

    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotateAngle * Time.deltaTime);

    private void ScaleSpikeBall()
    {
        currentScale += scaleFactor * scaleSpeed * Time.deltaTime;
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
        if (currentScale >= maxScale || currentScale <= minScale)
        {
            scaleFactor = -scaleFactor;
            isWaiting = true;
        }

        ApplyCurrentScale();
    }

    private void ApplyCurrentScale() => transform.localScale = new Vector3(currentScale, currentScale, 1);

    private void HandleWaiting()
    {
        timer += Time.deltaTime;
        if (timer >= scaleDelay)
        {
            isWaiting = false;
            timer = 0f;
        }
    }
}