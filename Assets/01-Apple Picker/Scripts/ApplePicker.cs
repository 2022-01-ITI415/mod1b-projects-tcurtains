using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i<numBaskets; i++) 
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }

    public void AppleDestroyed() 
    {
        //destroy all falling apples
        GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGo in tAppleArray) 
        {
            Destroy(tGo);
        }

        // destroy one basket
        //get index of last basket in basketList
        int basketIndex = basketList.Count-1;
        // get ref to Basket GameObject
        GameObject tBasketGo = basketList[basketIndex];
        // remove basket from list and destroy GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
