using System.ComponentModel;

namespace Nubimetrics.Common
{
    public static class SaveFile
    {
        public static void SaveToCsv<T>(List<T> reportData, string path)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            
            File.WriteAllLines(path, lines.ToArray());
        }
    }
}
