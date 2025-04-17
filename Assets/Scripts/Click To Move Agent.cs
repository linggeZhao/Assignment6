using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public enum ClickMode
{
    Mode2D,
    Mode3D
}

[RequireComponent(typeof(Seeker))]
public class ClickToMoveAgent : MonoBehaviour
{
    public ClickMode clickMode = ClickMode.Mode2D;
    [SerializeField] private LayerMask raycastLayers = -1;
    [SerializeField] private Seeker seekerAI;

    public void Awake()
    {
        if (seekerAI == null) seekerAI = GetComponent<Seeker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            switch (clickMode)
            {
                case ClickMode.Mode2D:
                    Raycast2D(ray);
                    break;
                case ClickMode.Mode3D:
                    Raycast3D(ray);
                    break;
            }
        }
    }

    private void Raycast2D(Ray ray)
    {
        RaycastHit2D hitInfo = Physics2D.GetRayIntersection(ray, Mathf.Infinity, raycastLayers);

        if (hitInfo.collider != null)
            seekerAI.StartPath(transform.position, hitInfo.point, OnPathComplete);
    }

    private void Raycast3D(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, raycastLayers))
            seekerAI.StartPath(transform.position, hitInfo.point, OnPathComplete);
    }

    private void OnPathComplete(Path path)
    {
        Debug.Log($"Path calculation complete. Any errors? - {path.error}");
    }
}
