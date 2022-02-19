using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    public BlockSpawn spawner;
    public GameManager gameManager;
    Rigidbody2D rigid;

    void Start()
    {
        //프리팹 스크립트 연결
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawner = GameObject.Find("Spawner").GetComponent<BlockSpawn>();
    }

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
