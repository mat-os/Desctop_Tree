
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{

    [SerializeField]
    private float _step;
    [SerializeField]
    private GameObject _branch;
    [SerializeField]
    private GameObject _sun;
    public bool begine;

    [Range(0,80)]
    public int BranchAngleMax;
    [Range(-80,0)]
    public int BranchAngleMin;

    public void Start()
    {
        //Random.InitState(799999);
        if(begine)
            DrawNewLine(transform.position.x, transform.position.y, 10, -5, Color.red);

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _step++;
        }

    }

    public void DrawNewLine(float x, float y, int len, float angle, Color colour) 
    {

        double x1, y1;
        x1 = x + _sun.transform.position.x + len * Mathf.Sin(angle * Mathf.PI * 2 / 360);
        y1 = y + _sun.transform.position.y + len * Mathf.Cos(angle * Mathf.PI * 2 / 360);
        if (len < 7f)
        {
            colour = Color.green;
        }
        Debug.DrawLine(new Vector2(x, y), new Vector2((int)x1, (int)y1), colour, 99999);
        var Newbranch = Instantiate(_branch, new Vector2((int)x1, (int)y1), Quaternion.identity);
        len--;
        float chance = Random.Range(0f,100f);
        if (chance > 50)
            Newbranch.GetComponent<Generation>().DrawNewLine((int)x, (int)y, len, Random.Range(BranchAngleMin, BranchAngleMax), colour);
        if (len > 1)
            Newbranch.GetComponent<Generation>().DrawNewLine((int)x1, (int)y1, len, Random.Range(BranchAngleMin, BranchAngleMax), colour);
    }

}
