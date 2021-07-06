using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class csFighter : MonoBehaviour
{
    int Speed = 30; // 전투기 속도
    float fw = Screen.width * 0.08f;  // 전투기 폭
    float fh = Screen.height * 0.08f; // 전투기 높이

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveFighter();
    }
    
    void MoveFighter()
    {
        float amtMove = Speed * Time.smoothDeltaTime;
        float key = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 전투기 월드 좌표 -> 스크린좌표로 변환
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

        if(key < 0 && pos.x > fw || (key >0 && pos.x < Screen.width - fw))
        {
            transform.Translate(Vector3.right * amtMove * key, Space.World);
        }

        // 전투기 위아래로 움직임
        if (v < 0 && transform.position.z > -1 || (v > 0 && transform.position.z < 27))
        {
            //Debug.Log(transform.position.z);
            transform.Translate(Vector3.forward * amtMove * v, Space.World);
        }

        // 전투기 약간 회전
        transform.eulerAngles = new Vector3(0, 0, -key * 20);
    }
}
