using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform CameraTransform;
    private float shakeDur = 1f, shakeAmoun = 0.1f, decreaseFactor = 1f;
    private Vector3 origPos;

    private void Start()
    {
        CameraTransform = GetComponent<Transform>();
        origPos = CameraTransform.localPosition;
    }
    private void Update()
    {
        if (shakeDur > 0)
        {
            CameraTransform.localPosition = origPos + Random.insideUnitSphere * shakeAmoun;
            shakeDur -= Time.deltaTime * decreaseFactor;
        } else
        {
            shakeDur = 0;
            CameraTransform.localPosition = origPos;
        }
    }
}
