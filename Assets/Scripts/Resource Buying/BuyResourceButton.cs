using UnityEngine;
using System.Collections;

public class BuyResourceButton : MonoBehaviour {

    public void OnClick(){
        Messenger.Broadcast("RESOURCE_BUY");
    }
}
