using ExcelDataReader;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class ExcelReader 
{
    //读取Excel表的数据，下面是需要的所有信息
    public struct ExcelData
    {
        public string SpeakerName;      
        public string SpeakerAvatar;
        public string SpeakerContent;
        public string BackGroundImage;
        public string BackGroundMusic;
        public string Character1Image;
        public string Character2Image;
        public string Character1Action;
        public string Character2Action;
        public string Character1Value;
        public string Character2Value;
    }
    //读取指定路径的Excel表格
    public static List<ExcelData>Read(string path)
    {
        List<ExcelData>res=new List<ExcelData>();
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        using (Stream stream = File.Open(path, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                do
                {
                    while (reader.Read())
                    {
                        var data = new ExcelData();
                        data.SpeakerName=reader.IsDBNull(0)? string.Empty : reader.GetValue(0)?.ToString();
                        data.SpeakerAvatar=reader.IsDBNull(1)?string.Empty : reader.GetValue(1)?.ToString();
                        data.SpeakerContent = reader.IsDBNull(2) ? string.Empty : reader.GetValue(2).ToString();
                        data.BackGroundImage=reader.IsDBNull(3)?string.Empty:reader.GetValue(3)?.ToString();
                        data.BackGroundMusic = reader.IsDBNull(4) ? string.Empty : reader.GetValue(4).ToString();
                        data.Character1Image = reader.IsDBNull(5) ? string.Empty : reader.GetValue(5).ToString();
                        data.Character2Image = reader.IsDBNull(6) ? string.Empty : reader.GetValue(6).ToString();
                        data.Character1Action = reader.IsDBNull(7) ? string.Empty : reader.GetValue(7).ToString();
                        data.Character2Action= reader.IsDBNull(8) ? string.Empty : reader.GetValue(8).ToString();
                        data.Character1Value= reader.IsDBNull(9) ? string.Empty : reader.GetValue(9).ToString();
                        data.Character2Value = reader.IsDBNull(10) ? string.Empty : reader.GetValue(10).ToString();
                        res.Add(data);
                    }
                }
                while (reader.NextResult());
            }
        }
        return res;
    }
}
