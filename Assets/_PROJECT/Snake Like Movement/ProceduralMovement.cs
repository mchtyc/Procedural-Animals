using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ProceduralMovement : MonoBehaviour
{
    public Transform[] goList;
    public float maxDistance = 2f;
    public float speed = 10f;

    void Start()
    {
        float scale_ = 2;
        foreach (Transform t in goList)
        {
            t.localScale = Vector3.one * scale_;
            scale_ *= 0.9f;
        }
    }
    
    void Update()
    {
        transform.position += Time.deltaTime * speed * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        for(int i = 0; i < goList.Length - 1; i++)
        {
            Transform before_ = goList[i];
            Transform after_ = goList[i + 1];
            LineRenderer line_ = before_.GetChild(0).GetComponent<LineRenderer>();

            if (Vector3.Distance(after_.position, before_.position) >= maxDistance)
            {
                Vector3 dir_ = (after_.position - before_.position).normalized;
                after_.position = before_.position + (dir_ * maxDistance);
            }

            line_.SetPosition(1, after_.position - before_.position);
        }
    }

    void OnDrawGizmos()
    {
        Handles.color = Color.black;

        foreach (Transform go in goList)
        {
            Handles.DrawWireDisc(go.position, Vector3.up, maxDistance);
        }
    }
}
