using UnityEngine;
using System.Collections;

public class OpenResourceBuyPanel : MonoBehaviour {

    [SerializeField]private GameObject resourceBuyPanel;
    public DishManager.Categories resourceCategory;

	public void OnClick(){
        resourceBuyPanel.GetComponent<ResourceBuyer>().setResourceCategory(resourceCategory);
        resourceBuyPanel.SetActive(true);
        Debug.Log("Button Clicked!");
    }
}
