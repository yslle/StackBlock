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
    public float posYBlockMove;
    int SpawnObj;

    public int count;
    GameObject lastBlock;
    public bool isClickable;

    void Start()
    {
        // pos = blockMove.transform.position;
        posYBlockMove = blockMove.transform.position.y;
        count = 0;
        isClickable = true;
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
            if (EventSystem.current.IsPointerOverGameObject() == false && isClickable == true) //UI 위가 아니며 클릭 가능 상태
            {
                isClickable = false;    // 추락 중에 클릭 안되도록
                count++;
                Debug.Log("Mouse Click: " + count);
                pos = blockMove.transform.position;
                
                //새로 생성
                GameObject clone = Instantiate(newBlock, pos, Quaternion.identity);
                clones.Add(clone);
                
                Debug.Log(pos);
            }
        }
    }
}
