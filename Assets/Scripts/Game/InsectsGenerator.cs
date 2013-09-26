using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Game
{
    public class InsectsGenerator : MonoBehaviour
    {
        public GameObject[] SpawnPoints;
        public GameObject[] Insects;

        private void Update()
        {
            SpawnInsect();
        }

        public void SpawnInsect()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                Generator.SpawnTheInsect(Insects,SpawnPoints);
            }
        }
    }

    public static class Generator
    {
        private static byte DoRand(int count)
        {
            Random rand = new Random();
            byte result = (byte)rand.Next(count);
            return result;
        }

        private static byte GetInsectNumber(int insCount)
        {
            byte insNum = DoRand(insCount);
            return insNum;
        }

        private static byte GetSpawnNum(int spawnCount)
        {
            byte spawnNum = DoRand(spawnCount);
            return spawnNum;
        }

        public static void SpawnTheInsect(GameObject[] insects, GameObject[] spPoints)
        {
            byte insectNumber = GetInsectNumber(insects.Length);
            byte spawnPointNumber = GetSpawnNum(spPoints.Length);
            GameObject insect = insects[insectNumber];
            GameObject spPoint = spPoints[spawnPointNumber];

            Object.Instantiate(insect,spPoint.transform.position, spPoint.transform.rotation);
        }
    }
}