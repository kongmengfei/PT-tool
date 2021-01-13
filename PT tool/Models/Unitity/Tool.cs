using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace PT_tool.Models.Unitity
{
    public static class Tool
    {
        public static string ConvertToTreeJson(List<Topic> potential_support_topic_list)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartArray();

                potential_support_topic_list.ForEach(item =>
                {
                    writer.WriteStartObject();

                    // 写 label 属性
                    writer.WritePropertyName("label");
                    writer.WriteValue(item.name);

                    // 写 value 属性
                    writer.WritePropertyName("value");
                    writer.WriteValue(item.id);

                    // 判断 它是否 第一个属性，展开
                    if (item.name.Equals("SharePoint"))
                    {
                        writer.WritePropertyName("expanded");
                        writer.WriteValue(true);
                    }

                    // 写 children 
                    if(item.children!=null && item.children.Count != 0)
                    {
                        WriteChildren(writer,item.children);
                    }

                    
                    writer.WriteEndObject();
                });

                writer.WriteEnd();                                         
            }

            return sb.ToString();
        }


        //
        private static void WriteChildren(JsonWriter writer,List<Topic> Children)
        {
            writer.WritePropertyName("children");
            writer.WriteStartArray();
            Children.ForEach(item =>
            {
                writer.WriteStartObject();

                // 写 label 属性
                writer.WritePropertyName("label");
                writer.WriteValue(item.name);

                // 写 value 属性
                writer.WritePropertyName("value");
                writer.WriteValue(item.id);

                // 写 children 
                if (item.children != null && item.children.Count != 0)
                {

                    WriteChildren(writer, item.children);
                }

                writer.WriteEndObject();
            });
            writer.WriteEndArray();
        }

    }
}