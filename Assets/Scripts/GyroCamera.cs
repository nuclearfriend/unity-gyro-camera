using UnityEngine;

public class GyroCamera : MonoBehaviour
{	
	// Private methods
	//--------------------------------

	void Awake()
	{
		if (SystemInfo.supportsGyroscope)
		{
			Input.gyro.enabled = true;
			GyroFix();
		}
		else
		{
			enabled = false;
		}
	}

    void Update()
    {
        transform.localRotation = GyroToUnity(Input.gyro.attitude);
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("Supports Gyro: " + SystemInfo.supportsGyroscope);	
        GUILayout.Label("Orientation: " + Screen.orientation);	
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("iphone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
    }

	void GyroFix()
	{
		// Create a parent object containing the camera (you could do this manually in the 
		// hierarchy if preferred, or here in code)
		GameObject camParent = new GameObject ("CamParent");
		camParent.transform.position = transform.position;
		transform.parent = camParent.transform;
		
		// Rotate the parent object by 90 degrees around the x axis
		camParent.transform.Rotate(Vector3.right, 90);
	}

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
