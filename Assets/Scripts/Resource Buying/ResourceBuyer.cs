using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceBuyer : MonoBehaviour {

	private DishManager.Categories resourceCategory = DishManager.Categories.Fish;
    private int amountSelected;
    private int price = 1;
    private int totalPrice;

    [SerializeField]private GameObject priceText;
    [SerializeField]private GameObject totalPriceText;

    void Awake(){
        Messenger<int>.AddListener("RESOURCE_AMOUNT_SELECTED", OnAmountSelected);
        Messenger.AddListener("RESOURCE_BUY", OnResourceBuy);
        Debug.Log("ResourceBuyer Listeners Added");
    }

    void OnDestroy(){
        Messenger<int>.RemoveListener("RESOURCE_AMOUNT_SELECTED", OnAmountSelected);
        Messenger.RemoveListener("RESOURCE_BUY", OnResourceBuy);        
    }

    void Start(){
        SetStoreType();
        setDailyPrice();
    }

    void Update(){
        if(gameObject.activeSelf){
            SetStoreType();
        }
    }

    private void setDailyPrice(){
        priceText.GetComponent<Text>().text = "Today's Price: $" + price;
    }

    private void setTotalPrice(){
        totalPrice = amountSelected * price;
        totalPriceText.GetComponent<Text>().text = "Total: $" + totalPrice;
    }

    private void OnAmountSelected(int selectedAmount){
        amountSelected = selectedAmount;
        setTotalPrice();

        Debug.Log("Looking to buy " + amountSelected + " " + resourceCategory + " for $" + totalPrice);

    }

    private void OnResourceBuy(){
        if(totalPrice <= PlayerControl.control.getPlayerData().money){
            PlayerControl.control.changeMoney(-totalPrice);

            PlayerControl.control.changeResourceAmount(resourceCategory, amountSelected);

            Debug.Log("Bought " + amountSelected + " " + resourceCategory + " for $" + totalPrice);
        }
    }

    private void SetStoreType(){
        Messenger<DishManager.Categories>.Broadcast("SET_STORE_TYPE", resourceCategory);
    }

    public void toggleViewResourceBuyer(){
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void setResourceCategory(DishManager.Categories category){
        resourceCategory = category;
    }
}
