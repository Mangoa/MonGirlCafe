using UnityEngine;
using System.Collections;

public class AmountButton : MonoBehaviour {

	public int amount;

    public void OnClick(){
        Messenger<int>.Broadcast("RESOURCE_AMOUNT_SELECTED", amount);
    }
}
