using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custom_Target : MonoBehaviour {

    public List<Transform> targets;
    public Transform findTargets;
    private Transform myTransform;
    // Use this for initialization
    void Start()
    {
        findTargets = null;
        targets = new List<Transform>();
        AddAllEnemies();
        myTransform = transform;
        TargetEnemy();
        DeselectTarget();
    }



    public void AddAllEnemies()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in go)
            AddTarget(enemy.transform);
    }

    public void AddTarget(Transform enemy)
    {
        targets.Add(enemy);
    }
    private void SortTargetsByDistance()
    {
        targets.Sort(delegate (Transform t1, Transform t2)
        {
            return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));
        });
    }
    private void TargetEnemy()
    {

        if (targets.Count < 1)
            return;
        SortTargetsByDistance();

        DeselectTarget();
        findTargets = targets[0];
        checkDead();

        SelectTarget();

    }
    private void checkDead()
    {
        EnemyHealth eh = (EnemyHealth)findTargets.GetComponent("EnemyHealth");
        if (!eh.alive)
        {
            targets.Remove(findTargets);
            TargetEnemy();

        }
        Debug.Log("Enemy has " + eh.currentHealth + " HP");
    }
    private void DeselectTarget()
    {
        if (findTargets != null)
            findTargets.transform.Find("Targeted").gameObject.SetActive(false);
    }
    private void SelectTarget()
    {
        Custom_Attack pa = (Custom_Attack)GetComponent("Custom_Attack");
        pa.target = findTargets.gameObject;

        findTargets.transform.Find("Targeted").gameObject.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TargetEnemy();
        }
    }
}
