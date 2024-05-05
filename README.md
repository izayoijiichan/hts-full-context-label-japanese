# Izayoi HTS-style Full-context label (Japanese)

This is HTS-style full-context label serialiser and deserializer.

## Usage


~~~csharp
    using Izayoi.Hts.FullContextLabel.Japanese;
    using Izayoi.Hts.FullContextLabel.Japanese.Serialization;
    //using Izayoi.OpenJTalk.Lang.CSharp;

    static void Main()
    {
        FullContextLabelSerializer labelSerializer = new();

        List<string> labelStringList;

        {
            labelStringList = ReadLabelFile("SomeJapaneseText.lab");
        }
        {
            //labelStringList = openJTalk.ExtractLabel("こんにちは");
        }

        List<Label> labelObjectList = labelSerializer.Deserialize(labelStringList);

        List<string> labelStringList2 = labelSerializer.Serialize(labelObjectList);
    }
~~~

___
Last updated: 6 May, 2024  
Editor: Izayoi Jiichan

*Copyright (C) 2024 Izayoi Jiichan. All Rights Reserved.*
