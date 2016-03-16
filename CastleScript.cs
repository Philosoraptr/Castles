using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleScript : MonoBehaviour {
	public bool enemyCastle;
	public bool playerCastle;
	public float period = 0.1f;
	public int castleHP;
	public Text castleHPText;
	public GameObject unitPref;

	private float nextActionTime = 0.0f;

	void Start () {
	
	}

	void Update () {
		if(enemyCastle || playerCastle) {
			if (Time.time > nextActionTime){
				nextActionTime = Time.time + period;
				AdjustCastleHP(1);
			}
		}
	}

	void AdjustCastleHP(int hpIncrement) {
		castleHP += hpIncrement;
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

	void SpawnUnits(Gameobject enemyCastleObj){
		AdjustCastleHP(-(castleHP/2));
		GameObject unit = Instantiate(unitPref) as GameObject;
		unit.transform.position = new vector2(this.transform.position.x + this.collider2d.size.x, this.transform.position.y, this.collider2d.size.y);
		unit.transform.position.MoveTowards(New Vector2(unit.transform.position.x, unit.transform.position.y), enemyCastleObj.transform.position, 3 * Time.deltaTime);
		//unit.transform.position.movetowards(unit.transform.position, castle2.position, 3 * Time.deltaTime);
		//Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta); 
	}
}













