using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialog")]
public class DialogSeting
{
    // Start is called before the first frame update
    [XmlElement("node")] public Node[] nodes;

    public static DialogSeting Load(TextAsset xml) 
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DialogSeting));
        StringReader reader = new StringReader(xml.text);
        DialogSeting dialog = serializer.Deserialize(reader) as DialogSeting;
        return dialog;
    }


}

[System.Serializable]
public class Node
{
    [XmlAttribute("char_id")] public int id;

    [XmlElement("text")] public string text;

   

    [XmlElement("endnode")] public string end;

    [XmlArray("answers")] [XmlArrayItem("answer")] public Answer[] answers;
}

[System.Serializable]
public class Answer
{
    [XmlAttribute("tonode")] public int tonode;

    [XmlElement("ans_text")] public string answerText;

    [XmlElement("end")] public string end;
   
    [XmlElement("tolevel")] public string level;
}
