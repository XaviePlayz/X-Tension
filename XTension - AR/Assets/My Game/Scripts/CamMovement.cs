using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rot;

    [SerializeField] private string selectableTag1 = "Creature";
    [SerializeField] private string selectableTag2 = "Sluggor";
    [SerializeField]private new Camera camera;

    public void Start()
    {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnableGyro();
    }

    public void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }

        Ray ray = camera.ScreenPointToRay(transform.forward);
        Debug.DrawRay(ray.origin, transform.forward * 15f, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit))
        {
            var selection = raycastHit.transform;
            if (selection.CompareTag(selectableTag1))
            {
                raycastHit.collider.GetComponent<Creature>().TakeDamage(1);
            }
            if (selection.CompareTag(selectableTag2))
            {
                raycastHit.collider.GetComponent<Sluggor>().TakeDamage(1);
            }
        }
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }

        return false;
    }
}
