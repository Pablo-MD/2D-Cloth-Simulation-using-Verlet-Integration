using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Node class where different values are store and functions for setting up the nodes of the cloth are
public class Node
{
    public Transform nodeTransform;
    public Vector3 position, previousPosition;
    public bool isFixed;
    public float m;

    LineRenderer lr;
    public Node(Vector2 _position, Vector2 size, float m)
    {
        nodeTransform = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        nodeTransform.position = _position;
        position = _position;
        previousPosition = position*.995f;
        nodeTransform.localScale = size;
    }
    public void SetInMatrix(int i, int j, Transform parent)
    {
        ClothGenerator clothGenerator = parent.parent.GetComponent<ClothGenerator>();
        nodeTransform.name = ("Node (" + i + ", " + j + ")");
        nodeTransform.parent = parent.transform;
        nodeTransform.gameObject.AddComponent<NodeCoord>().coord = new Vector2Int(i, j);
        nodeTransform.tag = "Node";
        Material nodeMaterial = nodeTransform.GetComponent<Renderer>().material;
        nodeMaterial.SetColor("White", Color.white);
        nodeMaterial = isFixed == true ? clothGenerator.whiteNode : clothGenerator.blackNode;
        lr=nodeTransform.gameObject.AddComponent<LineRenderer>();
        lr.startWidth = 0.07f;
        lr.loop = true;
        lr.material = clothGenerator.stickMaterial;
    }

    public void ConnectionLines(Node[] nearestNodes)
    {  
        lr.positionCount = nearestNodes.Length+1;
        Vector3[] drawingNodes = new Vector3[nearestNodes.Length + 2];
        drawingNodes[0] = this.position;
        for (int i=0; i < nearestNodes.Length; i++)
        {
            drawingNodes[i + 1] = nearestNodes[i].position;
        }           
        lr.SetPositions(drawingNodes);
    }


    //Create a Destructor for the falling Nodes (Later)
}

public class Stick
{
    public Node nodeA, nodeB;
    public float length;

    public Stick(Node A, Node B)
    {
        nodeA = A;
        nodeB = B;
        length = (nodeA.position - nodeB.position).magnitude;
    }
}