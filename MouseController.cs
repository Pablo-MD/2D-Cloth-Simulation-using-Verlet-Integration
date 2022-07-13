using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField]
    Material whiteNode;
    [SerializeField]
    Material blackNode;

    public Texture2D cursorTexture;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        StartCoroutine(MouseTrace(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        //When pressed and collide, get reference of the Coord class that the node has to get the index position of the array in cloth generator.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))             
            {
                if (hit.collider.CompareTag("Node"))
                {
                    NodeCoord nodeCoord = hit.collider.GetComponent<NodeCoord>();
                    Node clothNode = hit.transform.parent.parent.GetComponent<ClothGenerator>().nodes[nodeCoord.coord.x,nodeCoord.coord.y];
                    clothNode.isFixed = clothNode.isFixed == true ? false : true;
                    Material nodeMaterial = clothNode.nodeTransform.GetComponent<Renderer>().material;
                    nodeMaterial = clothNode.isFixed == true ? whiteNode : blackNode;
                }
            }
        }

    }

    //Just wanted to check the mouse working, could have used the trace function that Unity has.
    private IEnumerator MouseTrace(Vector2 position)
    {
        GameObject sphereIndicator = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphereIndicator.transform.position = position;
        sphereIndicator.transform.localScale = new Vector3(.1f,.1f,0);
        yield return new WaitForSeconds(.5f);
        GameObject.DestroyImmediate(sphereIndicator);
    }




}
