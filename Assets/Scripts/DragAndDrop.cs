using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    public GameObject selectedPiece;
    int OrderInLayer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("puzzle"))
            {
                if (!hit.transform.GetComponent<PieceScript>().InRightPosition)
                {
                    selectedPiece = hit.transform.gameObject;
                    selectedPiece.GetComponent<PieceScript>().Selected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = OrderInLayer;
                    OrderInLayer++;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (selectedPiece!=null)
            {
                selectedPiece.GetComponent<PieceScript>().Selected = false;
                selectedPiece = null;
            }
        
        }
        if(selectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPiece.transform.position = new Vector3(MousePoint.x,MousePoint.y,0);
        }
    }
}
