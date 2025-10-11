using System.Collections.Generic;

namespace AudioButton
{
    internal static class EnumGenerator
    {
        private const string FILE_FORMAT = "" +
            "namespace AudioButton\r\n" +
            "{\r\n" +
            "\t//Сгенерировано автоматически\r\n" +
            "\tpublic enum SoundId\r\n" +
            "\t{\r\n" +
            "{0}" +
            "\t}\r\n" +
            "}";
        private const string LINE_FORMAT = "\t\t{0},\r\n";

        public static string Gen(IEnumerable<string> sources)
        {
            string resultString = "";

            foreach (var source in sources)
                resultString += LINE_FORMAT.Replace("{0}", source);

            return FILE_FORMAT.Replace("{0}", resultString);
        }
    }
}