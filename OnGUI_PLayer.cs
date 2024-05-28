using UnityEngine;

/* 
    OnGUI (Immediate Mode GUI System)
    Pros:
        1. simplicity - directy write drawing code, no additional setup
        2. dynamic updates - good for debugging
    Cons:
        1. performance - redraws every frame
        2. legacy system - outdated, not recommended by unity
 */

public class OnGUI_PLayer : MonoBehaviour
{
    public float MoveSpeed = 8f;
    public float TurnSpeed = 180f;

    private void Update()
    {
        float MoveValue = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * MoveValue * MoveSpeed * Time.deltaTime);

        float TurnValue = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up, TurnValue * TurnSpeed * Time.deltaTime);
    }
    private void OnGUI()
    {
        OnGui_ScreenText("OnGUI");
        OnGui_OverheadLabel("Moopy");
    }
    private void OnGui_ScreenText(string text)
    {
        // set style and display text on screen
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 36; // Set the font size
        guiStyle.normal.textColor = Color.white; // Set the text color
        Rect screentext_rect = new Rect(10, 10, 300, 50);
        GUI.Label(screentext_rect, text, guiStyle);
    }
    private void OnGui_OverheadLabel(string text)
    {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 24; // Set the font size
        guiStyle.normal.textColor = Color.red; // Set the text color
        Vector3 labellocation = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, 4.5f, 0)); //convert 3D to 2D
        labellocation.y = Screen.height - labellocation.y; //flip the y-coordinate as OnGUI's y-coordinate is from the top
        GUI.Label(new Rect(labellocation.x - 50, labellocation.y - 25, 100, 50), text, guiStyle);
    }

}
