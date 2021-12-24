using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using StateV2;

namespace PTD_Demo
{
    public class StorefrontButton : MonoBehaviour
    {
        [SerializeField] private Button _myButton;
        [SerializeField] private TMP_Text _myText;

        public void InitializeButton(Action<ShopMerchandiseSO> callback, ShopMerchandiseSO merch)
        {
            _myButton.onClick.AddListener(() => callback(merch));
            _myText.text = merch.merchName;
            gameObject.name = merch.name;
        }
    }
}