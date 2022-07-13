using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicSimulation : MonoBehaviour
{
    ClothGenerator cloth;
    Node[] web;
    List<Stick> sticks;
    [SerializeField]
    PhysicsConstants constants;

    void Start()
    {
        //Get reference of the cloth generator and instantate the node array and stick array to pass into the Verlet function.
        cloth = gameObject.GetComponent<ClothGenerator>();
        web = new Node[cloth.x * cloth.y];
        sticks = new List<Stick>();

        int n = 0;
        for (int i = 0; i < cloth.x; i++)
        {
            for (int j = 0; j < cloth.y; j++)
            {
                web[n] = cloth.nodes[i, j];
                n++;
                if (!(i + 1 == cloth.x))
                {
                    sticks.Add(new Stick(cloth.nodes[i, j], cloth.nodes[i + 1, j]));
                }
                if (!(j + 1 == cloth.y))
                {
                    sticks.Add(new Stick(cloth.nodes[i, j], cloth.nodes[i, j + 1]));

                }
            }
        }

    }

    void Update()
    {
        PhysicsSimulation.Verlet(web, sticks.ToArray(), constants.g);
        foreach (Node node in web)
        {
            node.nodeTransform.position = node.position;
        }
    }
}
