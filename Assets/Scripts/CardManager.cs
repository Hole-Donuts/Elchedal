using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoleDonuts
{


    public class CardManager : MonoBehaviour
    {
        public List<Sprite> SpriteCard = new List<Sprite>();
        public List<GameObject> ImageCard = new List<GameObject>();
        public GameObject PrefabCard;
        public int maxCard = 3;
        public Transform canvas;
        int index;
        GameObject card;
        public void Start()
        {
            SPawn();
            SpriteCard.Shuffle(5);
            
        }
        public void Update()
        {
            StartCoroutine(Activated());
        }

        void SPawn()
        {

            for (int i = 0; i < maxCard; i++)
            {

                card = Instantiate(PrefabCard, transform.position, Quaternion.identity, canvas);
                ImageCard.Add(card);
                card.GetComponent<Image>().sprite = SpriteCard[i%SpriteCard.Count];
                card.SetActive(false);
            }
        }

      
        IEnumerator Activated()
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < ImageCard.Count; i++)
            {
                ImageCard[i].SetActive(true);
            }
        }
    }
}