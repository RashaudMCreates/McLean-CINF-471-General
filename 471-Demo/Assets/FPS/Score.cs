using UnityEngine;

public class Score : MonoBehaviour
{

    //Score is very broken, Forgive the ugly code


    int enemies = 0;
    int newenemy = 0;

    [SerializeField]
    GameObject cube1;
    [SerializeField]
    GameObject cube2;
    [SerializeField]
    GameObject cube3;
    [SerializeField]
    GameObject cube4;
    [SerializeField]
    GameObject cube5;
    [SerializeField]
    GameObject cube6;
    [SerializeField]
    GameObject cube7;
    [SerializeField]
    GameObject cube8;
    [SerializeField]
    GameObject cube9;
    [SerializeField]
    GameObject cube10;
    [SerializeField]
    GameObject cube11;
    [SerializeField]
    GameObject cube12;
    [SerializeField]
    GameObject cube13;
    [SerializeField]
    GameObject cube14;
    [SerializeField]
    GameObject cube15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = 13;
    }

    // Update is called once per frame
    void Update()
    {
        if (newenemy <= 0)
        {
            print("You Win!!!");
        }
    }

   /* private void OnDestroy(cube1) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube2) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube3) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube4) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube5) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube6) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube7) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube8) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube9) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube10) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube11) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube12) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube13) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube14) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }
    private void OnDestroy(cube15) {
        newenemy = (enemies - 1);
        print("Enemies Left: " + newenemy);
    }*/
}
