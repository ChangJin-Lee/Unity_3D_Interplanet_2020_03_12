using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class csFighter : MonoBehaviour
{
    int Speed = 30; // ������ �ӵ�
    float fw = Screen.width * 0.08f;  // ������ ��
    float fh = Screen.height * 0.08f; // ������ ����

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

        // ������ ���� ��ǥ -> ��ũ����ǥ�� ��ȯ
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

        if(key < 0 && pos.x > fw || (key >0 && pos.x < Screen.width - fw))
        {
            transform.Translate(Vector3.right * amtMove * key, Space.World);
        }

        // ������ ���Ʒ��� ������
        if (v < 0 && transform.position.z > -1 || (v > 0 && transform.position.z < 27))
        {
            //Debug.Log(transform.position.z);
            transform.Translate(Vector3.forward * amtMove * v, Space.World);
        }

        // ������ �ణ ȸ��
        transform.eulerAngles = new Vector3(0, 0, -key * 20);
    }
}
