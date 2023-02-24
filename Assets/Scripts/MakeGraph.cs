using System.Collections.Generic;

public class MakeGraph {
    private static MakeGraph _instance;

    public Dictionary<string, Destination> Graph { get; }

    private MakeGraph() {
        var csvFile = CsvLoader.GetInstance().CsvData;
        Graph = new Dictionary<string, Destination>();
        foreach (var data in csvFile) Graph.Add(data[0], new Destination(data[0]));
        foreach (var data in csvFile) {
            for (var i = 1; i < 3; i++) {
                if (i == 1) {
                    if (data[i] == "") continue;
                    Graph[data[0]].Front = data[i];
                    Graph[data[i]].Back = data[0];
                }
                else {
                    if (data[i] == "") continue;
                    Graph[data[0]].Right = data[i];
                    Graph[data[i]].Left = data[0];
                }
            }
        }
    }

    public static MakeGraph GetInstance() {
        return _instance ??= new MakeGraph();
    }
}