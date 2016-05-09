using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {
	private GameObject originObj;
	private GameObject destinationObj;
	private bool active;

	public void SetTargetCastle(GameObject playerCastle, GameObject enemyCastle){
		originObj = playerCastle;
		destinationObj = enemyCastle;
		active = true;
	}

	void Start () {
		gameObject.transform.position = new Vector2(originObj.transform.position.x + (originObj.GetComponent<BoxCollider2D>().size.x / 2.0f), 
		                                            originObj.transform.position.y);
	} 

	void Update () {
		if (active){
			gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, destinationObj.transform.position, Time.deltaTime);
			if(GetComponent<Collider2D>().OverlapPoint(destinationObj.transform.position)){
				destinationObj.GetComponent<CastleScript>().AdjustCastleHP(-1);
				Destroy(gameObject);
			}
		}
	}
}
