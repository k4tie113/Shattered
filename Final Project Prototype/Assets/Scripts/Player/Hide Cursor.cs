using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HideCursor : MonoBehaviour
{
   
    private Camera camera1;
    public RawImage crosshair;
    public Texture whiteCrosshair;
    public Texture redCrosshair;
    void Start()
    {
        camera1 = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera1.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), camera1.transform.forward, out hit, 100))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
            }
        }

    }
}