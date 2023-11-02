using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject _shopPanel;
    private Player  _player;
    
    private int _price, _item;
     

    private void Start()
    {
       _player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Update()
    {
       
       
    }
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            _shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            _shopPanel.SetActive(false);
        }
    }
    public void ItemPick(int Item)
    {

        Debug.Log("ShopItem:" + Item);
      
        switch (Item)
        {
            case 0:
                _item = 1;
                _price = 200;
                UiManager.Program.SelectBarPos(84.8f);
                Debug.Log("Fire Sword Picked");
                break;
            case 1:
                _item = 2;
                _price = 400;
                UiManager.Program.SelectBarPos(-12.9f);
                Debug.Log("Boots");
                break;
            case 2:
                _item = 3;
                _price = 100;
                UiManager.Program.SelectBarPos(-118.75f);
                Debug.Log("Keys");
                break;

        }

    }
    public void CheckOut()
    {

        if (_player._diamondHave >= _price && _item > 0)
        {
            switch (_item)
            {
                case 1:
                    Debug.Log("You Got Fire Sword");
                    break;

                case 2:
                    Debug.Log("You Got Boots Of Flight");
                    break;

                case 3:
                    Debug.Log("You Got Keys");
                    GameManager.Program.PlayerGotKey();
                    break;
            }

            _player._diamondHave -= _price;
            _item = 0;
            _price = 0;
            UiManager.Program.HideSelectBar();
            _shopPanel.SetActive(false);
            return;
        }
        else if (_player._diamondHave <= _price)
        {
            Debug.Log("Need more Gems");
        }

        if (_item == 0 && _price == 0)
        {
            Debug.Log("Pick a Item");
        }



    }
}
