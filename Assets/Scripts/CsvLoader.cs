using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CsvLoader {
    private static CsvLoader _instance;
    private List<string[]> _csvData;

    public List<string[]> CsvData {
        get {
            if (_csvData == null) {
                throw new NullReferenceException("CSVファイルはNULLだZOY☆");
            }

            return _csvData;
        }
    }


    private CsvLoader() {
        _csvData = new List<string[]>();
        LoadCsv();
    }

    private void LoadCsv() {
        var csv = Resources.Load(Setting.FileName) as TextAsset;
        if (csv != null) {
            var reader = new StringReader(csv.text);
            while (reader.Peek() != -1) {
                _csvData.Add(reader.ReadLine()!.Split(','));
            }
        }
        else {
            throw new FileNotFoundException("ファイルが無いZOY☆");
        }
    }

    public static CsvLoader GetInstance() {
        return _instance ??= new CsvLoader();
    }
}