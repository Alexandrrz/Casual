using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 5f;
    private Transform rotator;
    private void Start()
    {
        rotator = GetComponent<Transform>();
    }

    void Update()
    {
        rotator.Rotate(0, speed * Time.deltaTime, 0);
    }
}
