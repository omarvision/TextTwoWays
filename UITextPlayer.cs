using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
    UI.Text (Unity UI system)
    Pros:
        1. performance - unity optimized
        2. flexibility - visual controls for layout, anchoring
        3. interactivity - handles user input
    Cons:
        1. requires canvas and event handler elements
 */

public class UITextPlayer : MonoBehaviour
{
    public float MoveSpeed = 8f;
    public float TurnSpeed = 180f;
    public GameObject lbl = null;
    public Camera cam = null;

    private void Update()
    {
        float MoveValue = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * MoveValue * MoveSpeed * Time.deltaTime);

        float TurnValue = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up, TurnValue * TurnSpeed * Time.deltaTime);

        if (cam != null)
        {
            Vector3 directionAwayFromCamera = lbl.transform.position - cam.transform.position;
            lbl.transform.rotation = Quaternion.LookRotation(directionAwayFromCamera);
            // Optional: Adjust the rotation to keep the text upright
            lbl.transform.rotation = Quaternion.Euler(0, lbl.transform.rotation.eulerAngles.y, 0);
        }
    }
}
