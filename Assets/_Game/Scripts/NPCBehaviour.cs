using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float movementSpeed;

    [SerializeField] private bool isAlive;
    [SerializeField] private bool isMerchant;
    [SerializeField] private bool isFriend;
    [SerializeField] private bool isImmune;
    [SerializeField] private bool isDamageable;
    [SerializeField] private bool isEnemy;

    [SerializeField] private bool isTrading;
    [SerializeField] private bool tradeMenuFlag;
    [SerializeField] private bool onRangeforTrade;
    [SerializeField] private bool isExitingTrade;

    [SerializeField] private string playerOnTrade;


    [SerializeField] private GameObject tradeMenu;


    // ==========================================================
    // ==========================================================
    //             STARTS / UPDATES
    // ==========================================================
    // ==========================================================

    // Start is called before the first frame update
    void Start()
    {
        if (health > 0)
        {
            isAlive = true;
            isTrading = false;
            tradeMenuFlag = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Health handler
        
        // If dead do stuff
        if (health <= 0)
        {
            isAlive = false;
            Debug.Log(name + " is now Dead");
            gameObject.SetActive(false);
        }

        // If alive can do stuff
        if (isAlive)
        {
            if (isFriend)
            {
                isDamageable = false;
            }

            if (isEnemy)
            {
                isDamageable = true;
            }

            if (isMerchant && isFriend)
            {
                if (onRangeforTrade && isTrading == false && Input.GetKeyDown(KeyCode.Q))
                {
                    TradeMenuED();
                }
                else if (onRangeforTrade && isTrading && Input.GetKeyDown(KeyCode.Z))
                {
                    TradeMenuED();
                }
            }
            else if (isMerchant == false && isFriend)
            {
                Debug.Log("HEy friend, im not a merchant");
            }
        }
    }

    // ==========================================================
    // ==========================================================
    //             COLLIDERS
    // ==========================================================
    // ==========================================================

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log(name + " is now Colldiding with: " + other.gameObject.name);

        if (isAlive)
        {
            // Damage
            // If the character is NOT IMMUNE and is ALIVE, this damage works if the DamageMarker appears when doing the attack
            if (isDamageable & isEnemy)
            {
                Debug.Log(name + ": Im Colliding with player: " + other.name);
                if (isEnemy && other.gameObject.tag == "isDamageMarker")
                {
                    //Debug.Log(name + ": Health before: " + health + "Damage to receivbe: " + other.gameObject.GetComponentInParent<AttackHandler>().damage);
                    //health = health - other.gameObject.GetComponentInParent<AttackHandler>().damage;
                    Debug.Log(name + ": Health now: " + health);
                }
            }

            // Not Trader
            // If this character is a FRIEND and NOT a MERCHANT
            if (isFriend && isMerchant == false)
            {
                Debug.Log(" Regular Dialogue opens");
            }

            // If the collider object is a Player and is not a new player
            if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player>().onRangeForTrade == false && isMerchant)
            {
                Debug.Log("Se habiliutan los trades");
                onRangeforTrade = true;
                other.gameObject.GetComponent<Player>().onRangeForTrade = true;
            }
        }
    }

    private void OnTriggerStay(UnityEngine.Collider other)
    {
            
    }

    private void OnTriggerExit(UnityEngine.Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Se deshabiliutan los trades");
            tradeMenuFlag = false;
            tradeMenu.SetActive(false);
            Debug.Log("Se Cierra menu de trades por rango");
            isTrading = false;
            onRangeforTrade = false;
            other.gameObject.GetComponent<Player>().onRangeForTrade = false;
        }
    }
    // ==========================================================
    // ==========================================================
    //             METHODS / FUNCTIONS
    // ==========================================================
    // ==========================================================

    private void TradeMenuED()
    {
        Debug.Log("Ya entre al Trade ED, su flag esta en: " + tradeMenuFlag);

        if (tradeMenuFlag == false)
        {
            tradeMenuFlag = true;
            tradeMenu.SetActive(true);
            Debug.Log("Se abre menu de trades por botonazo");
            isTrading = true;
        }
        else
        {
            tradeMenuFlag = false;
            tradeMenu.SetActive(false);
            Debug.Log("Se Cierra menu de trades por botonazo");
            isTrading = false;
        }
    }

}
