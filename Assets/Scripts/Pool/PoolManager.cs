using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;


    public static Dictionary<string, Pool> poolDic = new Dictionary<string, Pool>();


    public void Add(Pool p)
    {

        if (poolDic.ContainsKey(p.name))
        {
            return;
        }
        else
        {
            poolDic.Add(p.name, p);
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
