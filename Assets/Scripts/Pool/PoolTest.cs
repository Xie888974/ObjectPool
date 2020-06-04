using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    //public GameObject needPrefab;

    public List<GameObject> objArray = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            GameObject obj = PoolManager.poolDic["BulletPool"].BirthGameObject(PoolTypes.BULLET, Vector3.zero, Quaternion.identity);
            objArray.Add(obj);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {

            if (objArray.Count > 0)
            {

                PoolManager.poolDic["BulletPool"].RecoverGameObject(objArray[0]);
                objArray.RemoveAt(0);

            }
        }


    }
}
