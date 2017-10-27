using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {


	public float timeleft = 0;

	public RaycastHit hit; 

	public Transform currentdoor;

	public bool open;

	public bool isOpeningDoor;

	public Transform cam;

	public LayerMask mask; 




	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F) && timeleft == 0.0f)
			CheckDoor ();

		if (isOpeningDoor)
			OpenAndCloseDoor ();
	}


public void CheckDoor()
	{
		Debug.DrawLine (cam.position, cam.position + new Vector3(0,0,-5), Color.red);

		if (Physics.Raycast (cam.position, cam.position + new Vector3 (0, 0, -5), out hit, 100f, mask))
		{
			Debug.Log ("GaOpen"); 

			open = false;
			if (hit.transform.localRotation.eulerAngles.y > 45)
				open = true; 

			isOpeningDoor = true; 
			currentdoor = hit.transform;
		}
	}

	public void OpenAndCloseDoor()
	{
		timeleft += Time.deltaTime;
		if (open)
			currentdoor.localRotation = Quaternion.Slerp (currentdoor.localRotation, Quaternion.Euler(0,0,0), timeleft);
		else
			currentdoor.localRotation = Quaternion.Slerp (currentdoor.localRotation, Quaternion.Euler(0,90,0), timeleft);

		if (timeleft > 1) 
		{
			timeleft = 0;
			isOpeningDoor = false; 
		}
	}



}