using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenColider : MonoBehaviour
{
    EdgeCollider2D edgeCollder;
    public GameObject Monster;
    public float time;
    public string LevelName;

    public void LoadLevel()
    {
        StartCoroutine(MyCoroutine());
    }
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(LevelName);
    }
    void Awake()
    {
        edgeCollder = this.GetComponent<EdgeCollider2D>();
        CreateEdgeCollider();;
    }
    
    private void Update()
    {
        time += Time.deltaTime;
    }

    //call this at start and whenever the resolution changes
    void CreateEdgeCollider()
    {
        List<Vector2> edges = new List<Vector2>();
        edges.Add(Camera.main.ScreenToWorldPoint(Vector2.zero));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)));
        edges.Add(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)));
        edges.Add(Camera.main.ScreenToWorldPoint(Vector2.zero));
        edgeCollder.SetPoints(edges);
    }

    //runs when colliding if collider set to Trigger
    void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D colliderRB = collider.GetComponent<Rigidbody2D>();
        //contact point is gotten by raycasting in the colliders velocity direction at the colliders position.
        RaycastHit2D[] hit2D = Physics2D.RaycastAll(collider.transform.position, colliderRB.velocity);
        //second one is being used because first one is self, could probably ignore self-layer and get as Physics2D.Raycast() instead
        Vector2 contactPoint = hit2D[1].point;
        //Get normal of contact point by creating a line from the contact point to the closest collider point and rotating 90�
        Vector2 normal = Vector2.Perpendicular(contactPoint - GetClosestPoint(collider.transform.position)).normalized;
        //reflect the current velocity at the edge normal
        colliderRB.velocity = Vector2.Reflect(colliderRB.velocity, normal);

        if (time > 15)
        {
            LoadLevel();
        }

        Debug.Log("Bounce");
    }

    //Goes through edgeCollider Points and returns the one closest to position
    Vector2 GetClosestPoint(Vector2 position)
    {
        Vector2[] points = edgeCollder.points;
        float shortestDistance = Vector2.Distance(position, points[0]);
        Vector2 closestPoint = points[0];
        foreach (Vector2 point in points)
        {
            if (Vector2.Distance(position, point) < shortestDistance)
            {
                shortestDistance = Vector2.Distance(position, point);
                closestPoint = point;
            }
        }
        return closestPoint;
    }
}

