using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleScript : MonoBehaviour {
	public bool enemyCastle;
	public bool playerCastle;
	public float period = 0.1f;
	public int castleHP;
	public Text castleHPText;

	private float nextActionTime = 0.0f;

	void Start () {
	
	}

	void Update () {
		if(enemyCastle || playerCastle) {
			if (Time.time > nextActionTime){
				nextActionTime = Time.time + period;
				CastleHPIncrease();
			}
		}
	}

	void CastleHPIncrease() {
		castleHP += 1;
		castleHPText.text = castleHP.ToString();
	}

	void MouseInputHandler(){
		//if (Input.touchCount == 1)
		if(Input.GetMouseButtonDown (0))
		{
			if(playerCastle){
				Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);//new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f
				Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);
				if (GetComponent<Collider2D>().OverlapPoint(touchPos))
				{
					Debug.Log("Castle Touched");
				}
			}
		}
	}
}
