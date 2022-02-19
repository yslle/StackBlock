using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    public BlockSpawn spawner;
    public GameManager gameManager;
    Rigidbody2D rigid;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "bottom") {
            if (spawner.count == 1) {
                gameManager.success();
            }
            else if (spawner.count > 1) {
                gameManager.fail();
            }
        }
        
        if (collision.gameObject.name != "bottom") {
            if (spawner.count - 1 == gameManager.score) {
                gameManager.success();
            }
        }
    }
}
