using Esri.ArcGISRuntime.ArcGISServices;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArcGISMapSample.MapService
{
    /// <summary>
    /// 高德地图
    /// </summary>
    public class AMapLayer : ServiceImageTiledLayer
    {
        public AMapLayer()
               : base(CreateTileInfo(), new Envelope(-20037508.3427892, -20037508.3427892, 20037508.3427892, 20037508.3427892, SpatialReferences.WebMercator))
        {
        }

        private static TileInfo CreateTileInfo()
        {
            var levels = new LevelOfDetail[19];
            double resolution = 20037508.3427892 * 2 / 256;
            double scale = resolution * 96 * 39.37;
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = new LevelOfDetail(i, resolution, scale);
                resolution /= 2;
                scale /= 2;
            }
            return new TileInfo(96, TileImageFormat.Png, levels, new MapPoint(-20037508.3427892, 20037508.3427892, SpatialReferences.WebMercator),
                 SpatialReferences.WebMercator, 256, 256);
        }



        protected override Task<Uri> GetTileUriAsync(int level, int row, int column, CancellationToken cancellationToken)
        {

            string url = "http://webrd0" + (column % 4 + 1) + ".is.autonavi.com/appmaptile?lang=zh_cn&size=1&scale=1&style=8&x=" + column + "&y=" + row + "&z=" + level;
            return Task.FromResult(new Uri(url, UriKind.Absolute));
        }
    }
}
