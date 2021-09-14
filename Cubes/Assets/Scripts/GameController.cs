using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public GameObject[] CubeToCreate;
    public Text scoreTxt;
    private CubePos nowCube = new CubePos(0, 1, 0);
    public float cubeChangePlaceSpeed = 0.5f;
    public Transform CubeToPlace;
    public GameObject allCubes, vfx;
    private Rigidbody allCubesRb;
    private bool IsLose;
    public GameObject[] CanvasStart;
    private bool firstCube;
    private float CamMoveToYPosition, CamMoveSpeed = 2f;
    private int prevCountMaxHorizontal;
    public Color[] bjColors;
    private Color toCameraColor;


    private List<Vector3> AllCubesPosition = new List<Vector3>()
    {
        new Vector3 (0, 0, 0),
        new Vector3 (1, 0, 0),
        new Vector3 (-1, 0, 0),
        new Vector3 (0, 1, 0),
        new Vector3 (0, 0, 1),
        new Vector3 (0, 0, -1),
        new Vector3 (1, 0, 1),
        new Vector3 (-1, 0, -1),
        new Vector3 (-1, 0, 1),
        new Vector3 (1, 0, -1),
    };
    private Transform mainCamera;
    private Coroutine showCubeToPlace;

    private void Start()
    {
        scoreTxt.text = "<color=#5627A7><size=33>SCORE:</size></color> " + PlayerPrefs.GetInt("score") + "\n <size=33> CUBE:</size> 0";
        toCameraColor = Camera.main.backgroundColor;
        mainCamera = Camera.main.transform;
        CamMoveToYPosition = 5.9f + nowCube.y - 1f;

        allCubesRb = allCubes.GetComponent<Rigidbody>();
        showCubeToPlace = StartCoroutine(ShowCubePlace());



    }

    private void Update()
    {
        
        
            if ((Input.touchCount > 0) && CubeToPlace != null && allCubes != null && !EventSystem.current.currentSelectedGameObject)
            {
                
                if (Input.GetTouch(0).phase != TouchPhase.Began && !EventSystem.current.currentSelectedGameObject)
                    return;
                if (!firstCube)
                {
                    firstCube = true;
                    foreach (GameObject obj in CanvasStart)
                    {
                        Destroy(obj);
                    }
                }
                GameObject newCube = Instantiate(CubeToCreate[PlayerPrefs.GetInt("Player")], CubeToPlace.position, Quaternion.identity) as GameObject;
                newCube.transform.SetParent(allCubes.transform);
                nowCube.setVector(CubeToPlace.position);
                AllCubesPosition.Add(nowCube.getVector());

                if (PlayerPrefs.GetString("music") != "No")
                    GetComponent<AudioSource>().Play();

                GameObject vfxGame = Instantiate(vfx, CubeToPlace.position, Quaternion.identity) as GameObject;
                Destroy(vfxGame, 2.5f);

                allCubesRb.isKinematic = true;
                allCubesRb.isKinematic = false;
                SpawnPositions();
                MoveCameraChangeBg();
            }
        
        //œ–Œ»√–€ÿ‹
        
        
        if (!IsLose && allCubesRb.velocity.magnitude > 0.1f)
        {
            Destroy(CubeToPlace.gameObject);
            IsLose = true;
            StopCoroutine(showCubeToPlace);
        }

       
        //œÀ¿¬ÕŒ≈ ƒ¬»∆≈Õ»≈  ¿Ã≈–€ ¬—À≈ƒ «¿  ”¡¿Ã»
        mainCamera.localPosition = Vector3.MoveTowards (mainCamera.localPosition, 
            new Vector3(mainCamera.localPosition.x, CamMoveToYPosition, mainCamera.localPosition.z),
            CamMoveSpeed * Time.deltaTime);

        if (Camera.main.backgroundColor != toCameraColor)
            Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, toCameraColor, Time.deltaTime / 1.5f);
    }
    IEnumerator ShowCubePlace()
    {
        while (true)
        {
            SpawnPositions();
            yield return new WaitForSeconds(cubeChangePlaceSpeed);
        }
    }
    private void SpawnPositions()
    {
        if (CubeToPlace != null)
        {
            List<Vector3> positions = new List<Vector3>();
            if (IsPositionEmpty(new Vector3(nowCube.x + 1, nowCube.y, nowCube.z)) && nowCube.x + 1 != CubeToPlace.position.x)
                positions.Add(new Vector3(nowCube.x + 1, nowCube.y, nowCube.z));
            if (IsPositionEmpty(new Vector3(nowCube.x - 1, nowCube.y, nowCube.z)) && nowCube.x - 1 != CubeToPlace.position.x)
                positions.Add(new Vector3(nowCube.x - 1, nowCube.y, nowCube.z));
            if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y + 1, nowCube.z)) && nowCube.y + 1 != CubeToPlace.position.y)
                positions.Add(new Vector3(nowCube.x, nowCube.y + 1, nowCube.z));
            if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y - 1, nowCube.z)) && nowCube.y - 1 != CubeToPlace.position.y)
                positions.Add(new Vector3(nowCube.x, nowCube.y - 1, nowCube.z));
            if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y, nowCube.z + 1)) && nowCube.z + 1 != CubeToPlace.position.z)
                positions.Add(new Vector3(nowCube.x, nowCube.y, nowCube.z + 1));
            if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y, nowCube.z - 1)) && nowCube.z - 1 != CubeToPlace.position.z)
                positions.Add(new Vector3(nowCube.x, nowCube.y, nowCube.z - 1));

            if (positions.Count > 1)
                CubeToPlace.position = positions[UnityEngine.Random.Range(0, positions.Count)];
            else if (positions.Count == 0)
                IsLose = true;
            else
                CubeToPlace.position = positions[0];
        }
    }
    private bool IsPositionEmpty(Vector3 targetPos)
    {
        if (targetPos.y == 0)
            return false;

        foreach (Vector3 pos in AllCubesPosition)
        {
            if (pos.x == targetPos.x && pos.y == targetPos.y && pos.z == targetPos.z)
                return false;
        }
        return true;
    }
    private void MoveCameraChangeBg()
    {
        int maxX = 0, maxY = 0, maxZ = 0, maxHor;
        foreach (Vector3 pos in AllCubesPosition)
        {
            if (Mathf.Abs(Convert.ToInt32(pos.x)) > maxX)
                maxX = Convert.ToInt32(pos.x);

            if (Convert.ToInt32(pos.y) > maxY)
                maxY = Convert.ToInt32(pos.y);

            if (Mathf.Abs(Convert.ToInt32(pos.z)) > maxZ)
                maxZ = Convert.ToInt32(pos.z);
        }
        if (PlayerPrefs.GetInt("score") < maxY)
            PlayerPrefs.SetInt("score", maxY);
        scoreTxt.text = "<color=#5627A7><size=33>SCORE:</size></color> " + PlayerPrefs.GetInt("score") + "\n <size=33> CUBE:</size> " + maxY;

        CamMoveToYPosition = 5.9f + nowCube.y - 1f;

        maxHor = maxX > maxZ ? maxX : maxZ;

                if (maxHor % 2 == 0 && prevCountMaxHorizontal != maxHor)
                {
                    mainCamera.localPosition += new Vector3(0, 0, -2f);
                    prevCountMaxHorizontal = maxHor;
                }
                if (maxY >= 60)
                    toCameraColor = bjColors[3];
                else if (maxY >= 40)
                    toCameraColor = bjColors[2];
                else if (maxY >= 20)
                    toCameraColor = bjColors[1];
                else if (maxY >= 10)
                    toCameraColor = bjColors[0];
    }

}

struct CubePos
{
    public int x, y, z;
    public CubePos (int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3 getVector()
    {
        return new Vector3 (x, y, z);
    }

    public void setVector(Vector3 pos)
    {
        x = Convert.ToInt32(pos.x);
        y = Convert.ToInt32(pos.y);
        z = Convert.ToInt32(pos.z);
    }
}
