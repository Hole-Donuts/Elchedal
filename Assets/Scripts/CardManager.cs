using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoleDonut
{
    public class CardManager : MonoBehaviour
    {
        public List<InventoryItem> Items = new List<InventoryItem>();
        public Transform transformParent;
        private int Maxcard = 3;
        private GameObject card;
        public GameObject canvas;
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetCard();
                gameObject.SetActive(true);
            }
        }

        private void SetCard()
        {
            for (int i = 0; i < Maxcard; i++)
            {
                GameObject card = Instantiate(Items[i]._Icon);
                card.transform.SetParent(transformParent,false);
                card.SetActive(true);
            }
        }

        public void ResetCard()
        {
            foreach (Transform child in transformParent.transform)
            {
                Destroy(child.gameObject);
            }
            Items.Shuffle(Items.Count);
            SetCard();
        }

        public void CloseRandomCard()
        {
            canvas.SetActive(false);
        }
    }
}