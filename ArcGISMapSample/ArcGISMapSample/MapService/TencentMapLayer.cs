using Esri.ArcGISRuntime.ArcGISServices;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArcGISMapSample.MapService
{
    /// <summary>
    /// 加载腾讯地图
    /// </summary>
    public class TencentMapLayer : ServiceImageTiledLayer
    {
        public TencentMapLayer()
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

            row = (int)Math.Pow(2, level) - 1 - row;
            var url = $"http://rt0.map.gtimg.com/realtimerender?z={level}&x={column}&y={row}&type=vector&style=0";
            return Task.FromResult(new Uri(url, UriKind.Absolute));
        }
    }
}
