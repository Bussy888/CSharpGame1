using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator sharedInstance;
    public List<LevelBlock> allBlocks = new List<LevelBlock>(); //Lista que contiene los bloques creados
    public List<LevelBlock> currentBlocks = new List<LevelBlock>(); //Lista que contien los bloques en pantalla
    public Transform levelInitialPoint;
    private bool isGeneratinginital = false;

    private void Awake()
    {
        sharedInstance  = this;
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateInitialBlocks()
    {
        isGeneratinginital = true;
        for(int i = 0; i<2; i++)
        {
            AddNewBlock();
        }
        isGeneratinginital = false;
    }


    public void AddNewBlock()
    {
        int randomIndex = Random.Range(0, allBlocks.Count);

        if (isGeneratinginital)
        {
            randomIndex = 0;
        }

        LevelBlock block = (LevelBlock)Instantiate(allBlocks[randomIndex]);
        block.transform.SetParent(this.transform, false);

        //Posicion del Bloque
        Vector3 blockPosition = Vector3.zero;
        if(currentBlocks.Count == 0)
        {
            //Colocar primer bloque
            blockPosition = levelInitialPoint.position;
        }
        else
        {
            //Ya tengo bloques en pantalla y se conecta al ultimo
            blockPosition = currentBlocks[currentBlocks.Count - 1].exitPoint.position;
        }
        block.transform.position = blockPosition;
        currentBlocks.Add(block);
    }
    public void RemoveOldBLock()
    {
        LevelBlock block = currentBlocks[0];
        currentBlocks.Remove(block);
        Destroy(block.gameObject);
    }
    public void RemoveAllBlocks()
    {
        while(currentBlocks.Count > 0)
        {
            RemoveOldBLock();
        }
    }
}
