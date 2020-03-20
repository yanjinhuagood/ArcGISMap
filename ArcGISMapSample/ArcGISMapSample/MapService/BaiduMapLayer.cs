using Esri.ArcGISRuntime.ArcGISServices;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArcGISMapSample.MapService
{
    /// <summary>
    /// 加载百度地图
    /// </summary>
    public class BaiduMapLayer :ServiceImageTiledLayer
    {
        public BaiduMapLayer()
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
            return new TileInfo(96, TileImageFormat.Png, levels, new MapPoint(-20037508.3427892, 20037508.3427892, new SpatialReference(102100)),
                 SpatialReferences.WebMercator, 256, 256);
        }


        protected override Task<Uri> GetTileUriAsync(int level, int row, int col, CancellationToken cancellationToken)
        {

            var zoom = level - 1;
            var offsetX = (int)Math.Pow(2, zoom);
            var offsetY = offsetX - 1;
            var numX = col - offsetX;
            var numY = (-row) + offsetY;
            var num = (col + row) % 8 + 1;
            var url = "http://online" + num + ".map.bdimg.com/tile/?qt=tile&x=" + numX + "&y=" + numY + "&z=" + level + "&styles=pl&udt=20170706"; ;
            
            return Task.FromResult(new Uri(url, UriKind.Absolute));
        }
    }
}
