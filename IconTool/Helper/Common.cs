using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IconTool.Helper
{
    public static class Common
    {
        public static string GetPathBySvgData(string svgData,bool isCompressed) {
            if (svgData == null) {
                return "";
            }
            if (isCompressed) {
                var paths = svgData.Split("|");
                Geometry path = null;
                foreach (var pathStr in paths) {
                    path = path == null ? Geometry.Parse(pathStr) : Geometry.Combine(path, Geometry.Parse(pathStr),GeometryCombineMode.Union,null);
                }
            }
            return svgData.Replace("|", " ");
        }
    }
}
