using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceImage : MonoBehaviour {

    [SerializeField]public Sprite[] resourceSprites;

	void Awake(){
        Messenger<DishManager.Categories>.AddListener("SET_STORE_TYPE", ChangeImage);
    }

    void OnDestroy(){
        Messenger<DishManager.Categories>.RemoveListener("SET_STORE_TYPE", ChangeImage);
    }

    private void ChangeImage(DishManager.Categories category){
        switch(category){
            case DishManager.Categories.Fish:
                GetComponent<Image>().sprite = resourceSprites[0];
                break;
            case DishManager.Categories.Veggie:
                GetComponent<Image>().sprite = resourceSprites[1];
                break;
        }
    }
}
