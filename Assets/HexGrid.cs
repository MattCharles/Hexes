using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

    public int width = 6;
    public int height = 6;
    public float defaultPlaneSize = 10f;

    public Color defaultColor = Color.white;
    public Color touchedColor = Color.green;

    public HexCell cellPrefab;

    public Text cellLabelPrefab;
    Canvas gridCanvas;
    HexMesh hexMesh;

    HexCell[] cells;

    private void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();

        cells = new HexCell[height * width];

        // 6x6
        for (int z = 0, i = 0; z < height; z++) {
            for(int x=0; x<width; x++) {
                CreateCell(x, z, i++);
            }
        }

        //Hex
        //for(int z=1, i=0; z<4; z++)
        //{
        //    for(int x=2; x<4; x++)
        //    {
        //        CreateCell(x, z, i++);
        //   }
        //}
        //CreateCell(4, 2, 6);
    }

    private void Start()
    {
        hexMesh.Triangulate(cells);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(inputRay, out hit))
        {
            TouchCell(hit.point);
        }
    }

    void TouchCell(Vector3 position)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
        HexCell cell = cells[index];
        cell.color = touchedColor;
        hexMesh.Triangulate(cells);
        //Debug.Log("touched at " + position);
    }

    void CreateCell(int x, int z, int i) {
        Vector3 position;
        //position.x = x * defaultPlaneSize;
        position.x = (x + z * .5f - z/2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius*1.5f);

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.z);
        label.text = cell.coordinates.ToStringOnSeperateLines();
    }

}
