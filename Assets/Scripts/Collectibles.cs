using TMPro;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int coinsToGive = 1;
    public TextMeshProUGUI coinText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.coins += coinsToGive;
            coinText.text = player.coins.ToString();
            Destroy(gameObject);
        }
    }
}