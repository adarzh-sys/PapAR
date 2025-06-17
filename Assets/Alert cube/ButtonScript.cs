using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //public int cycleSensor;  // Your public integer
    public void OnClicking()
    {
        FindObjectOfType<AlertCubeScript>().cycleSensor = 1;
        //Debug.Log("button");
    }

}
