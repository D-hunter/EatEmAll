using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
	public class MoveMouth : MonoBehaviour {
		
		public GameObject[] SpawnPoints;
		Vector3 startPosition;
		void Start () {
			startPosition = this.transform.position;
		}
		
		void Update () {
			MoveBottom();
		}
		
		void MoveBottom(){
			int count = Input.touchCount;
			Touch touch;
			if(count>0){
				Debug.Log("CHECK!");
				for(int i=0;i<count;i++){
					touch = Input.GetTouch(i);
					if(touch.phase == TouchPhase.Began){
						Ray ray = Camera.main.ScreenPointToRay(touch.position);
						RaycastHit hit = new RaycastHit();
						if(Physics.Raycast(ray,out hit)){
							if(hit.collider.gameObject.tag == "bottom"){
								if(Vector3.Distance(this.transform.position,SpawnPoints[0].transform.position)>0.5)
								transform.position+= transform.up*1000f*Time.deltaTime;	
							}
						}
					}
				}
			
			}

		}
	}
}
