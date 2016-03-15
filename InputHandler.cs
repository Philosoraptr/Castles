using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour 
{
	public bool playerCastleTouched;
	public GameObject touchedPlayerCastle;
	public GameObject touchedBadCastle;

	void Update()
	{
		//if (Input.touchCount == 1)
		if(Input.GetMouseButtonDown (0))
		{
			Debug.Log("Mouse down");
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);//new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f
			Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);
			if (GetComponent<Collider2D>().OverlapPoint(touchPos))
			{
				playerCastleTouched = true;
				Debug.Log("Castle Touched");
			}
		}
	}
}
