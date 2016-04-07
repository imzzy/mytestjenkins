using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LPCommon
{
    public static class DataRowExtension
    {
        public static T ToEntity<T>(this DataRow dr) where T : class, new()
        {
            if (dr == null)
                return null;
            T item = new T();
            var table = dr.Table;
            Dictionary<string, string> cols = new Dictionary<string, string>();
            foreach (DataColumn col in table.Columns)
            {
                cols.Add(col.ColumnName.ToLower(), col.ColumnName);
            }
            foreach (FieldInfo prop in typeof(T).GetFields())
            {
                var lowerProp = prop.Name.ToLower();
                if (cols.ContainsKey(lowerProp))
                {
                    object value = Convert.ChangeType(dr[cols[lowerProp]], prop.FieldType);
                    prop.SetValue(item, value);
                }
            }
            foreach (var prop in typeof(T).GetProperties())
            {
                var lowerProp = prop.Name.ToLower();
                if (cols.ContainsKey(lowerProp))
                {
                    object value = Convert.ChangeType(dr[cols[lowerProp]], prop.PropertyType);
                    prop.SetValue(item, value);
                }
            }
            return item;
        }
    }
}
