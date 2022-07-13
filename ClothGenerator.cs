using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothGenerator : MonoBehaviour
{
    //Distance between nodes.
    [Range(0.1f, 2)]
    public float nodeSpacing = 1;

    public Node[,] nodes;
    //Dimentions of the cloth.
    public int x = 10;
    public int y = 10;

    //mass of each node, intented to use in the future for other simulations, not used now
    public float m = 1;

    public Material stickMaterial;
    public Material whiteNode;
    public Material blackNode;

    GameObject structure;

    //Should make an OnValidate() to create the cloth beforehand
    void Awake()
    {
        GenerateNodes();
        GenerateLines();
    }

    private void Update()
    {
        GenerateLines();
    }

    private void GenerateNodes()
    {
        
        nodes = new Node[x, y];
        //For organization
        structure = new GameObject("Nodes").gameObject;
        structure.transform.parent = gameObject.transform;

        //Calculation for a centered and symmetric cloth.
        float clothLenght = (y - 1) * nodeSpacing;

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                nodes[i, j] = new Node(new Vector2((j * nodeSpacing) - clothLenght / 2, -i * nodeSpacing), new Vector2(0.2f, 0.2f), m);
                nodes[i, j].SetInMatrix(i, j, structure.transform);
                if (i == 0) nodes[i, j].isFixed = true;
            }
        }
    }

    private void GenerateLines()
    {

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                List<Node> nearestNodes = new List<Node>();
                if (!(i + 1 == x))
                {
                    nearestNodes.Add(nodes[i + 1, j]);

                }
                if (!(j + 1 == y))
                {
                    nearestNodes.Add(nodes[i, j + 1]);

                }
                nodes[i, j].ConnectionLines(nearestNodes.ToArray());
            }
        }
    }
}

