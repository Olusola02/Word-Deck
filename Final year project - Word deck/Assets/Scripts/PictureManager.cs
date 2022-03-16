using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureManager : MonoBehaviour
{
    public Picture PicturePrefab;
    public Transform PicSpawnPosition;
    public Vector2 StartPosition = new Vector2(-2.15f, 3.62f);
    public GameObject back;
    List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };

    [HideInInspector]
    public List<Picture> PictureList;

    private Vector2 _offset = new Vector2(1.5f, 1.52f);

    /*private List<Material> _materialList = new List<Material>();
    private List<strings> _texturePathList = new List<string>();
    private Material Letter;
    private string _Letter;
    */


    // Start is called before the first frame update
    void Start()
    {
      
        SpawnPictureMesh(4, 5, StartPosition, _offset, false);
        MovePicture(4, 5, StartPosition, _offset);
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPictureMesh(int rows, int columns, Vector2 Pos, Vector2 offset, bool scaleDown)
    {
        for(int col = 0; col < columns; col++)
        {
            for(int row = 0; row < rows; row++)
            {
                var tempPicture = (Picture)Instantiate(PicturePrefab, PicSpawnPosition.position, PicSpawnPosition.transform.rotation);

                tempPicture.name = tempPicture.name + "c" + col + "r" + row;
                PictureList.Add(tempPicture);

                shuffleNum = rnd.Next(0, (faceIndexes.Count));

                GetComponent<Picture>().faceIndex = faceIndexes[shuffleNum];
                faceIndexes.Remove(faceIndexes[shuffleNum]);
            }
        }
    }

    private void MovePicture(int rows, int columns, Vector2 Pos, Vector2 offset) //moving to place
    {
        var Index = 0;
        for(var col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                var targetPosition = new Vector3((Pos.x + (offset.x * row)), (Pos.y - (offset.y * col)), 0.0f);
                StartCoroutine(MoveToPosition(targetPosition, PictureList[Index]));
                Index++;
            }
        }
    }

    private IEnumerator MoveToPosition(Vector3 target, Picture obj)
    {
        var randomDis = 7;

        while(obj.transform.position !=target)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, randomDis * Time.deltaTime);
            yield return 0;
        }
    }
}
