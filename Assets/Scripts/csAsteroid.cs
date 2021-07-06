using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csAsteroid : MonoBehaviour
{
    int Speed;
    int rotX, rotY, rotZ;

    int HP;

    Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();

        initAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        float amtMove = Speed * Time.smoothDeltaTime;

        transform.Rotate(new Vector3(rotX, rotY, rotZ) * Time.smoothDeltaTime);
        transform.Translate(Vector3.back * amtMove, Space.World);

        if(transform.position.z < -11)
        {
            Destroy(gameObject);
        }
    }

    void initAsteroid()
    {
        // � ũ�� -> �� ���� ������ ���ϰڴ�.
        float sizeX = Random.Range(1.5f, 2.5f);
        float sizeY = Random.Range(1.5f, 2.5f);
        float sizeZ = Random.Range(1.5f, 2.5f);

        transform.localScale = new Vector3(sizeX, sizeY, sizeZ);

        // ��� ���� ����
        float r = Random.Range(0.6f, 1);
        myRenderer.material.color = new Vector4(r, 0.8f, 0.8f, 1);

        // ��� �ӵ�, HP ����
        Speed = Random.Range(20, 50);
        HP = Random.Range(0, 5);

        // � ȸ�� �ӵ�
        rotX = Random.Range(-90, 90);
        rotY = Random.Range(-90, 90);
        rotZ = Random.Range(-90, 90);

        // � �ʱ� ��ġ
        float x = Random.Range(-28, 28);
        float z = Random.Range(37, 45);
        transform.position = new Vector3(x, 0, z);
    }
}
