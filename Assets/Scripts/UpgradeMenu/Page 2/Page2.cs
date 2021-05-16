using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


    public class Page2 : MonoBehaviour
    {
        [Header("PurchaseWindow")]
        public GameObject purchaseWindow;
        public TMP_Text pricePerItemText;
        public TMP_Text saleValueText;
        public TMP_Text descriptionText;
        public TMP_Text quantityText;
        public TMP_Text leftoverMoneyText;
        public GameObject ingredientSpriteBox;

        //Sales
        public float totalPrice;
        public int quantity;
        public TMP_Text playerCurrentCashText;
        public TMP_Text priceText;
        public Ingredient selectedItem;
        [Header("Other")]
        public GameObject nextDayButton;
        public UpgradeMenuHandler upgradeMenuHandler;
        

        private void Awake() 
        {
            upgradeMenuHandler = GetComponent<UpgradeMenuHandler>();
        }

        public void ShopItemSelected(Ingredient _selectedItem)
        {

            if (_selectedItem.discovered)
            {
                selectedItem = _selectedItem;
                quantity = 1;
                totalPrice = selectedItem.buyValue * quantity;
                purchaseWindow.SetActive(true);
                nextDayButton.SetActive(false);
            

                ingredientSpriteBox.GetComponent<Image>().sprite = selectedItem.sprite;
            

                string pricePerItem = selectedItem.buyValue.ToString("F2");
                string saleValue = selectedItem.sellValue.ToString("F2");

                pricePerItemText.text = $"${pricePerItem}   x";
                saleValueText.text = $"Sale Value: {saleValue}";
                descriptionText.text = $"{selectedItem.description}";
                quantityText.text = quantity.ToString();

                playerCurrentCashText.text = $"${SaveData.current.totalMoney.ToString("F2")}";
                priceText.text = $"-${(selectedItem.buyValue * quantity).ToString("F2")}";
                leftoverMoneyText.text = $"${(SaveData.current.totalMoney - (selectedItem.buyValue * quantity)).ToString("F2")}";
            }

            else
            {
                Debug.Log("Ingredient not yet discovered");
            }
        }

        public void IncreaseQuantity()
        {
            if (quantity >= 99)           
                quantity = 1;
            else
                quantity++;

            
            totalPrice = selectedItem.buyValue * quantity;
            quantityText.text = quantity.ToString();
            priceText.text = $"-${(totalPrice).ToString("F2")}";
            leftoverMoneyText.text = $"${(SaveData.current.totalMoney - (selectedItem.buyValue * quantity)).ToString("F2")}";
        }
        public void DecreaseQuantity()
        {
                quantity--;
                if (quantity == 0)           
                    quantity = 99;

            totalPrice = selectedItem.buyValue * quantity;
            quantityText.text = quantity.ToString();
            priceText.text = $"-${(totalPrice).ToString("F2")}";
            leftoverMoneyText.text = $"${(SaveData.current.totalMoney - (selectedItem.buyValue * quantity)).ToString("F2")}";
        }



        public void PurchaseOrder()
        {
            if (totalPrice <= SaveData.current.totalMoney)
            {
                Debug.Log(SaveData.current.totalMoney);
                SaveData.current.totalMoney -= totalPrice;

                switch (selectedItem.ingredientID)
                {
                    case "dog_001":
                        SaveData.current.count_playerInventory[0] += quantity;
                        break;

                    case "bun_001":
                        SaveData.current.count_playerInventory[3] += quantity;
                        break;

                    default:
                        break;
                }

                Debug.Log("Purchase Made");

                GetComponent<Page1>().UpdateStats();
                GetComponent<UpgradeMenuHandler>().UpdateMoney();
            }

            else
            {
                Debug.Log ("Purchase failed. Not enough money?");
            }
            ClosePurchaseWindow();

        }

        public void ClosePurchaseWindow()
        {
            purchaseWindow.SetActive(false);
            nextDayButton.SetActive(true);
        }

        public void unlockIngredientsTier2()
        {
            if (SaveData.current.achievementRewardClaimedArray[2] == false)
            {
            return;
            }
            upgradeMenuHandler.tier2Hotdog.discovered = true;
            upgradeMenuHandler.tier2Bun.discovered = true;
            GetComponent<Page1>().UpdateStats();
        }
        public void unlockIngredientsTier3()
        {
            if (SaveData.current.achievementRewardClaimedArray[3] == false)
            {
            return;
            }
            upgradeMenuHandler.tier3Hotdog.discovered = true;
            upgradeMenuHandler.tier3Bun.discovered = true;
            GetComponent<Page1>().UpdateStats();
        }
    }

