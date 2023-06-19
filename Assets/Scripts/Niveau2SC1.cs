
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveau2SC1 : MonoBehaviour
{
   [SerializeField] private Transform EmptySpace = null;
    private Camera _camera;
    [SerializeField] private Niveau2TilesScript[] tiles;
    private int EmptySpaceIndex=25;
    private bool _isFinished;
    [SerializeField] private GameObject endPanel;
    void Start()
    {
        _camera = Camera.main;
        shuffle();
    
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray= _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if(Vector2.Distance(EmptySpace.position, hit.transform.position) < 2)
                {
                    Vector2 lastEmptySpacePosition = EmptySpace.position;
                    Niveau2TilesScript thisTile = hit.transform.GetComponent<Niveau2TilesScript>();
                    EmptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = findIndex(thisTile);
                    /////////////////////////
                    tiles[EmptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                   EmptySpaceIndex = tileIndex;

                }
            }
        }
        if (!_isFinished)
        {
            int correcTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                        correcTiles++;
                }
            }
            if (correcTiles == tiles.Length - 1)
            {
                _isFinished = true;
                endPanel.SetActive(true);
                GetComponent<TimerScript>().stopTimer();
            }
        }
    }
    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void shuffle()
    {
        
        for(int i=0; i<=25; i++)
        {
            if (tiles[i]!= null)
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, 25);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex]=tile;

            }
        }
    }

    public int findIndex(Niveau2TilesScript ts)
    {
        for (int i=0; i<tiles.Length; i++)
        {
            if (tiles[i]!= null)
            {
                if (tiles[i] != ts) { return i; }
            }
        }
        return -1;
    }

    int getInversions()
    {
        int inversionsSum = 0;
        for (int i=0; i<tiles.Length; i++)
        {
            int thisTilesInversion = 0;
            for (int j=i; j<tiles.Length; j++)
            {
                if (tiles[i] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTilesInversion++;
                    }
                }
            }
            inversionsSum += thisTilesInversion;
        }
        return inversionsSum;

    }

}
