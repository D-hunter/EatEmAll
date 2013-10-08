using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game
{
    public class InsectsGenerator : MonoBehaviour
    {
        public GameObject[] SpawnPoints;
        public GameObject[] Insects;
		private float[] DropRates;
		public float SpawnDelay = 0.3f;
		float CurrentTime;
		
		private void Start()
		{
			CurrentTime = Time.time;	
		}
		
        private void Update()
		{			
		if(CurrentTime+SpawnDelay<=Time.time)
			{
				Generator.SpawnTheInsect(Insects,SpawnPoints);
				CurrentTime = Time.time;
			}	
        }
    }

    public static class Generator
    {
		private static float StandartInsectRate = 0.89f;
		private static float ExtraInsectRate = 0.1f;
		private static float BonusInsectRate = 0.01f;
		
		private static float S_GreenInsectRate = 0.46f;
		private static float S_RedInsectRate = 0.54f;
		
		private static float E_GreenInsectRate = 0.5f;
		private static float E_YellowInsectRate = 0.5f;
		
        private static int ChooseSpawnNumber()
        {
			double checkLine = Random.value;
            if(checkLine<0.33)
			{
				return 1;
			}
			else if(checkLine<0.66&&checkLine>0.33)
			{
				return 0;
			}
			else
			{
				return 2;
			}
        }
		
		private static float ChooseClassInsect(float Random_Value)
		{
			if (Random_Value<=StandartInsectRate){return StandartInsectRate;}
			if (Random_Value>StandartInsectRate && Random_Value<=StandartInsectRate+ExtraInsectRate){return ExtraInsectRate;}
			if (Random_Value>StandartInsectRate+ExtraInsectRate && Random_Value<=1f){return BonusInsectRate;}
			else{return StandartInsectRate;}	
		}
		
        public static void SpawnTheInsect(GameObject[] insects, GameObject[] spawnPoints)
        {			
			GameObject currentInsect=null;
			
			float CHOOSEN_INSECT = ChooseClassInsect(Random.value);
			
			if(CHOOSEN_INSECT == StandartInsectRate)
			{
				currentInsect = KindOfInsect(S_RedInsectRate,S_GreenInsectRate,insects[0],insects[1]);	
			}
			if(CHOOSEN_INSECT == ExtraInsectRate)
			{
				currentInsect = KindOfInsect(E_GreenInsectRate,E_YellowInsectRate,insects[2],insects[3]);
			}
			if(CHOOSEN_INSECT == BonusInsectRate)
			{
				currentInsect = insects[4];	
			}
			
            GameObject currentSpawnPoint = spawnPoints[ChooseSpawnNumber()];

            Object.Instantiate(currentInsect,currentSpawnPoint.transform.position, currentSpawnPoint.transform.rotation);
        }
		
		private static GameObject KindOfInsect(float BIGchance, float LOWchance, GameObject firstObject,GameObject secondObject)
		{
			if(Random.value<=BIGchance)
			{
				return firstObject;	
			}
			else
			{
				return secondObject;
			}
		}
    }
};