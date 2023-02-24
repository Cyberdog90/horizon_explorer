using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private float deltaT;
    public static float DeltaT;
    [SerializeField] private string csvFile = "graph.csv";
    public static string FileName;
    [SerializeField] private string entryPoint = "001.jpg";
    public static MakeGraph Graph;

    public static string NowPoint;

    [SerializeField] private Material center;
    [SerializeField] private Material outer;
    public static Material Center;
    public static Material Outer;

    private void Awake()
    {
        DeltaT = deltaT;
        FileName = csvFile;
        NowPoint = entryPoint;
        Center = center;
        Outer = outer;
        CsvLoader.GetInstance();
        Graph = MakeGraph.GetInstance();
        center.mainTexture = Graph.Graph[NowPoint].NowTexture.Texture;
    }
}