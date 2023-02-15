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
      
        private void Start()
        {
            Items.Shuffle(Items.Count);
            SetCard();
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

        public void closeUiDrawCard()
        {
            canvas.SetActive(false);
        }
        
    }
}