using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BlockSpawn spawner;
    public Text scoreShow;
    public GameObject failBox;
    public GameObject blockClone;
    public Vector3 posCam;
    public float camPosY;
    public int score;
    public Camera mainCam;

    //초기화
    void Start() {
        scoreShow = GameObject.Find("ScoreValue").GetComponent<Text>();
        score = 0;
        posCam = mainCam.transform.position;
        camPosY = posCam.y;
    }

    //성공한 경우
    public void success()
    {
        Debug.Log(score);

        // 카메라, blockMove 위로 이동
        if (score != 0) {
            posCam = mainCam.transform.position;
            mainCam.transform.position = new Vector3(posCam.x, posCam.y + 1, posCam.z);
            spawner.blockMove.transform.position = new Vector3(spawner.pos.x, spawner.pos.y + 1, spawner.pos.z);
        }

        score++;
        scoreShow.text = score.ToString();
    }

    //실패한 경우
    public void fail()
    {
        failBox.SetActive(true);
    }

    //재시작
    public void retry()
    {
        Debug.Log("retry");

        // 점수 초기화
        score = 0;
        scoreShow.text = score.ToString();

        // 카메라 위치 초기화
        mainCam.transform.position = new Vector3(posCam.x, camPosY, posCam.z);
        // resetGround();

        // blockMove 위치 초기화
        spawner.blockMove.transform.position = new Vector3(spawner.pos.x, spawner.posBlockMove, spawner.pos.z);
        
        // 모든 블록 없애기
        foreach (GameObject cloneBlock in spawner.clones){
            Destroy(cloneBlock);
        }

        // count 초기화
        spawner.count = 0;

        // failBox 안보이게
        failBox.SetActive(false);

    }

    //로비로 이동
    public void goToLobby()
    {
        Debug.Log("go to lobby");
        failBox.SetActive(false);
    }

}
