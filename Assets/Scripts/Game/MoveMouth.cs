using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
	public class MoveMouth : MonoBehaviour {
		
		public GameObject[] SpawnPoints;
		Vector3 startPosition;
		
		void Start () 
		{
			startPosition = transform.position;
		}
		
		void Update () 
		{
			MoveEater();
		}
		
		void MoveEater()
		{
			int count = Input.touchCount;
			Touch touch;
			if(Input.touchCount>0)
			{
				touch = Input.GetTouch(0);
				if(touch.phase == TouchPhase.Began)
				{
					Ray ray = Camera.main.ScreenPointToRay(touch.position);
					RaycastHit hit = new RaycastHit();
					if(Physics.Raycast(ray,out hit))
					{
						string tag = hit.collider.gameObject.tag;
						switch(tag)
						{
						case "bottom":transform.position= new Vector3(transform.position.x,SpawnPoints[0].transform.position.y,transform.position.z);break;
						case "top":transform.position= new Vector3(transform.position.x,SpawnPoints[2].transform.position.y,transform.position.z);break;
						case "center":transform.position= new Vector3(transform.position.x,SpawnPoints[1].transform.position.y,transform.position.z);break;
						default:transform.position=startPosition;break;
						}					
					}
				}
				else if(!(touch.phase == TouchPhase.Stationary||touch.phase == TouchPhase.Moved))
				{
					transform.position=startPosition;
				}
			}
		}
	}
}