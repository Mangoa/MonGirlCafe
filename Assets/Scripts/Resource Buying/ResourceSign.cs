using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceSign : MonoBehaviour {

	void Awake(){
        Messenger<DishManager.Categories>.AddListener("SET_STORE_TYPE", ChangeText);
    }
    
    void OnDestroy(){
        Messenger<DishManager.Categories>.RemoveListener("SET_STORE_TYPE", ChangeText);
    }

    private void ChangeText(DishManager.Categories category){
        switch(category){
            case DishManager.Categories.Fish:
                GetComponent<Text>().text = "Fish Market";
                break;
            case DishManager.Categories.Veggie:
                GetComponent<Text>().text = "Farmer's Market";
                break;
        }
    }
}
