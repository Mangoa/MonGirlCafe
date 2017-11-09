using UnityEngine;
using System.Collections;

public class CloseResourceBuyer : MonoBehaviour {

	[SerializeField]private GameObject resourceBuyPanel;

    public void OnClick(){
        resourceBuyPanel.SetActive(false);
    }
}
