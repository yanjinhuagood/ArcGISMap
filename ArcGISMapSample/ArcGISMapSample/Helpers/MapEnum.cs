using System.ComponentModel;

namespace ArcGISMapSample.Helpers
{
    public enum MapEnum
    {
        [Description("高德")]
        AMap,
        [Description("百度")]
        BaiduMap,
        [Description("腾讯")]
        TencentMap,
    }
}
