using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoleDonuts
{


    public class CardManager : MonoBehaviour
    {
        public List<GameObject> prefabs = new List<GameObject>();
        public int maxCard = 3;
        public Transform canvas;
        public void Start()
        {
            prefabs.Shuffle(5);
            SPawn();
        }
        public void Update()
        {

        }

        void SPawn()
        {

            for (int i = 0; i < maxCard; i++)
            {

                Instantiate(prefabs[i], transform.position, Quaternion.identity, canvas);
                Debug.Log(prefabs);
            }
        }


    }
}