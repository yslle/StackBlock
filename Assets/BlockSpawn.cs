using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.EventSystems;

public class BlockSpawn : MonoBehaviour
{
    public GameObject blockMove;
    public GameObject newBlock;
    public List<GameObject> clones;
    public Vector3 pos;
    public float posBlockMove;
    int SpawnObj;

    public int count;
    GameObject lastBlock;

    void Start()
    {
        pos = blockMove.transform.position;
        posBlockMove = pos.y;
        count = 0;
    }

    void Update()
    {
        SpawnBlock();
    }

    void SpawnBlock()
    {
        //마우스 클릭
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {  //UI이 위가 아니면
                count++;
                Debug.Log("Mouse Click: " + count);
                pos = blockMove.transform.position;
                // blockMove.transform.position = new Vector3(pos.x, pos.y, 0);
                
                //새로 생성
                GameObject clone = Instantiate(newBlock, pos, Quaternion.identity);
                clones.Add(clone);
                
                Debug.Log(pos);
            }
        }
    }
}
