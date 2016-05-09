using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleScript : MonoBehaviour {
	public bool enemyCastle;
	public bool playerCastle;
	public float period = 1.0f;
	public int castleHP;
	public Text castleHPText;
	public GameObject unitPref;

	private float nextActionTime = 0.0f;

	void Start () {
		castleHP = 0;
	}

	void Update () {
		if(enemyCastle || playerCastle) {
			if (Time.time > nextActionTime){
				nextActionTime = Time.time + period;
				AdjustCastleHP(1);
			}
		}
	}

	public void AdjustCastleHP(int hpIncrement) {
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

	public IEnumerator SpawnUnits(GameObject enemyCastleObj, float waitTime){
		int unitSpawnCount = castleHP/2;
		AdjustCastleHP(-unitSpawnCount);
		for (int i = 0; i <= unitSpawnCount; i++){
			yield return new WaitForSeconds(waitTime);
			GameObject unit = Instantiate(unitPref) as GameObject;
			unit.GetComponent<UnitController>().SetTargetCastle(gameObject, enemyCastleObj);
		}
	}
}













